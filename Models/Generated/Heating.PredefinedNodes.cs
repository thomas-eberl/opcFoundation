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
               "AwAAAB0AAABodHRwOi8vbWVzc3JpbmcuZGUvdWEvSGVhdGluZxUAAABodHRwOi8vbWVzc3JpbmcuZGUv" +
               "dWEdAAAAaHR0cDovL21lc3NyaW5nLmRlL1VBL0hlYXRpbmf/////AgAAACRgABAIAAAAAQAOAAAAVGhl" +
               "cm1vc3RhdFR5cGUBAQEAAwAAAAA1AAAAQSB0aGVybW9zdGF0IHRoYXQgY29udHJvbHMgdGhlIHRlbXBl" +
               "cmF0dXJlIG9mIGEgcm9vbS4AOv////8DAAAANWCJCwIAAAABAAsAAABUZW1wZXJhdHVyZQEBAgADAAAA" +
               "ACwAAABUaGUgbWVhc3VyZWQgdGVtcGVyYXR1cmUgaW4gZGVncmVlcyBDZWxzaXVzLgAvAQIBAABOAgAA" +
               "AAAL/////wEB/////wAAAAA1YIkLAgAAAAEACAAAAFNldHBvaW50AQEDAAMAAAAAOAAAAFRoZSB0YXJn" +
               "ZXQgdGVtcGVyYXR1cmUgaW4gZGVncmVlcyBDZWxzaXVzLCBmcm9tIDUgdG8gMzAuAC8APwBOAwAAAAAL" +
               "/////wMD/////wAAAAAkYYILBAAAAAEABQAAAEJvb3N0AQEEAAMAAAAAMQAAAFJhaXNlcyB0aGUgc2V0" +
               "cG9pbnQgYW5kIHJldHVybnMgdGhlIG5ldyBzZXRwb2ludC4ALwEBBAAATgQAAAABAf////8CAAAAF2Cp" +
               "CwIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBBQAALgBEAE4FAAAAlgEAAAABACoBAUsAAAAHAAAARGVn" +
               "cmVlcwAL/////wAAAAADAAAAAC0AAABUaGUgbnVtYmVyIG9mIGRlZ3JlZXMgdG8gYWRkIHRvIHRoZSBz" +
               "ZXRwb2ludC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQsCAAAAAAAPAAAAT3V0cHV0QXJndW1l" +
               "bnRzAQEGAAAuAEQATgYAAACWAQAAAAEAKgEBGgAAAAsAAABOZXdTZXRwb2ludAAL/////wAAAAAAAQAo" +
               "AQEAAAABAAAAAAAAAAEB/////wAAAAAkYIAKAQAAAAEACgAAAFRoZXJtb3N0YXQBAQcAAwAAAAAbAAAA" +
               "VGhlIGxpdmluZy1yb29tIHRoZXJtb3N0YXQuAC8BAQEABwAAAAEAAAAAIwEAVQMAAAA1YIkKAgAAAAEA" +
               "CwAAAFRlbXBlcmF0dXJlAQEIAAMAAAAALAAAAFRoZSBtZWFzdXJlZCB0ZW1wZXJhdHVyZSBpbiBkZWdy" +
               "ZWVzIENlbHNpdXMuAC8BAgEACAAAAAAL/////wEB/////wAAAAA1YIkKAgAAAAEACAAAAFNldHBvaW50" +
               "AQEJAAMAAAAAOAAAAFRoZSB0YXJnZXQgdGVtcGVyYXR1cmUgaW4gZGVncmVlcyBDZWxzaXVzLCBmcm9t" +
               "IDUgdG8gMzAuAC8APwkAAAAAC/////8DA/////8AAAAAJGGCCgQAAAABAAUAAABCb29zdAEBCgADAAAA" +
               "ADEAAABSYWlzZXMgdGhlIHNldHBvaW50IGFuZCByZXR1cm5zIHRoZSBuZXcgc2V0cG9pbnQuAC8BAQQA" +
               "CgAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQELAAAuAEQLAAAAlgEAAAAB" +
               "ACoBAUsAAAAHAAAARGVncmVlcwAL/////wAAAAADAAAAAC0AAABUaGUgbnVtYmVyIG9mIGRlZ3JlZXMg" +
               "dG8gYWRkIHRvIHRoZSBzZXRwb2ludC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAP" +
               "AAAAT3V0cHV0QXJndW1lbnRzAQEMAAAuAEQMAAAAlgEAAAABACoBARoAAAALAAAATmV3U2V0cG9pbnQA" +
               "C/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA"
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