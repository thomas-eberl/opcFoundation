/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Text;
using System.IO;
using Common;
using Opc.Ua;

namespace Common {}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1515 // Consider making public types internal
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1028 // Enum Storage should be Int32

namespace Heating
{
    #region _ClassName_ Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class PredefinedNodes
    {
        #region PredefinedNodes Declarations
        // <summary/>
        public static NodeStateCollection Load(ISystemContext context)
        {
            byte[] initializationBuffer = Convert.FromBase64String(
               "AgAAAB0AAABodHRwOi8vbWVzc3JpbmcuZGUvVUEvSGVhdGluZxUAAABodHRwOi8vbWVzc3JpbmcuZGUv" +
               "dWH/////AgAAACRgABAIAAAAAQAOAAAAVGhlcm1vc3RhdFR5cGUBAQEAAwAAAAA1AAAAQSB0aGVybW9z" +
               "dGF0IHRoYXQgY29udHJvbHMgdGhlIHRlbXBlcmF0dXJlIG9mIGEgcm9vbS4AOv////8DAAAANWCJCwIA" +
               "AAABAAsAAABUZW1wZXJhdHVyZQEBAgADAAAAACwAAABUaGUgbWVhc3VyZWQgdGVtcGVyYXR1cmUgaW4g" +
               "ZGVncmVlcyBDZWxzaXVzLgAvAQIBAABOAgAAAAAL/////wEB/////wAAAAA1YIkLAgAAAAEACAAAAFNl" +
               "dHBvaW50AQEDAAMAAAAAOAAAAFRoZSB0YXJnZXQgdGVtcGVyYXR1cmUgaW4gZGVncmVlcyBDZWxzaXVz" +
               "LCBmcm9tIDUgdG8gMzAuAC8APwBOAwAAAAAL/////wMD/////wAAAAAkYYILBAAAAAEABQAAAEJvb3N0" +
               "AQEEAAMAAAAAMQAAAFJhaXNlcyB0aGUgc2V0cG9pbnQgYW5kIHJldHVybnMgdGhlIG5ldyBzZXRwb2lu" +
               "dC4ALwEBBAAATgQAAAABAf////8CAAAAF2CpCwIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBBQAALgBE" +
               "AE4FAAAAlgEAAAABACoBAUsAAAAHAAAARGVncmVlcwAL/////wAAAAADAAAAAC0AAABUaGUgbnVtYmVy" +
               "IG9mIGRlZ3JlZXMgdG8gYWRkIHRvIHRoZSBzZXRwb2ludC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAA" +
               "ABdgqQsCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEGAAAuAEQATgYAAACWAQAAAAEAKgEBGgAAAAsA" +
               "AABOZXdTZXRwb2ludAAL/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAkYIAKAQAAAAEA" +
               "CgAAAFRoZXJtb3N0YXQBAQcAAwAAAAAbAAAAVGhlIGxpdmluZy1yb29tIHRoZXJtb3N0YXQuAC8BAQEA" +
               "BwAAAAEAAAAAIwEAVQMAAAA1YIkKAgAAAAEACwAAAFRlbXBlcmF0dXJlAQEIAAMAAAAALAAAAFRoZSBt" +
               "ZWFzdXJlZCB0ZW1wZXJhdHVyZSBpbiBkZWdyZWVzIENlbHNpdXMuAC8BAgEACAAAAAAL/////wEB////" +
               "/wAAAAA1YIkKAgAAAAEACAAAAFNldHBvaW50AQEJAAMAAAAAOAAAAFRoZSB0YXJnZXQgdGVtcGVyYXR1" +
               "cmUgaW4gZGVncmVlcyBDZWxzaXVzLCBmcm9tIDUgdG8gMzAuAC8APwkAAAAAC/////8DA/////8AAAAA" +
               "JGGCCgQAAAABAAUAAABCb29zdAEBCgADAAAAADEAAABSYWlzZXMgdGhlIHNldHBvaW50IGFuZCByZXR1" +
               "cm5zIHRoZSBuZXcgc2V0cG9pbnQuAC8BAQQACgAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0" +
               "QXJndW1lbnRzAQELAAAuAEQLAAAAlgEAAAABACoBAUsAAAAHAAAARGVncmVlcwAL/////wAAAAADAAAA" +
               "AC0AAABUaGUgbnVtYmVyIG9mIGRlZ3JlZXMgdG8gYWRkIHRvIHRoZSBzZXRwb2ludC4BACgBAQAAAAEA" +
               "AAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEMAAAuAEQMAAAAlgEA" +
               "AAABACoBARoAAAALAAAATmV3U2V0cG9pbnQAC/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8A" +
               "AAAA"
            );
            using (MemoryStream stream = new MemoryStream(initializationBuffer))
            {
                NodeStateCollection predefinedNodes = new NodeStateCollection();
                predefinedNodes.LoadFromBinary(context, stream, true);
                return predefinedNodes;
            }
        }
        #endregion
    }
    #endregion
}