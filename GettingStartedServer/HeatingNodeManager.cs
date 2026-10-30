using Opc.Ua;
using Opc.Ua.Server.Fluent;

namespace Heating;

[NodeManager(NamespaceUri = "http://example.com/Heating/")]
public partial class HeatingNodeManager
{
    private const double MinimumSetpoint = 5.0;
    private const double MaximumSetpoint = 30.0;

    private readonly Lock m_lock = new();
    private double m_setpoint = 21.0;

    partial void Configure(IHeatingNodeManagerBuilder builder)
    {
        builder.Thermostat.Temperature
            .PollEvery(TimeSpan.FromSeconds(1), SampleTemperature);
        builder.Thermostat.Setpoint
            .OnRead(ReadSetpoint)
            .OnWrite(WriteSetpoint);
        builder.Thermostat.Boost
            .OnCall(Boost);
    }

    // Simulates a measurement within half a degree of the setpoint.
    private double SampleTemperature()
    {
        return Math.Round(ReadSetpoint() - 0.5 + Random.Shared.NextDouble(), 1);
    }

    private double ReadSetpoint()
    {
        lock (m_lock)
        {
            return m_setpoint;
        }
    }

    private void WriteSetpoint(double value)
    {
        CheckSetpoint(value);
        lock (m_lock)
        {
            m_setpoint = value;
        }
    }

    private double Boost(double degrees)
    {
        lock (m_lock)
        {
            double newSetpoint = m_setpoint + degrees;
            CheckSetpoint(newSetpoint);
            m_setpoint = newSetpoint;
            return newSetpoint;
        }
    }

    // The client receives the status code of an exception that a callback throws.
    private static void CheckSetpoint(double setpoint)
    {
        if (setpoint is not (>= MinimumSetpoint and <= MaximumSetpoint))
        {
            throw new ServiceResultException(
                StatusCodes.BadOutOfRange,
                $"The setpoint must be from {MinimumSetpoint} to {MaximumSetpoint}.");
        }
    }
}