﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace VP.Native
{
    internal static class DataHandlers
    {
        internal static byte[] GetData(IntPtr instance, DataAttributes attribute)
        {
            int length;
            var ptr    = Functions.vp_data(instance, attribute, out length);
            var result = new byte[length];

            Marshal.Copy(ptr, result, 0, length);
            return result;
        }

        internal static void SetData(IntPtr instance, DataAttributes attribute, byte[] data)
        {
            var length = data.Length;
            var ptr    = Marshal.AllocHGlobal(length);
            Marshal.Copy(data, 0, ptr, length);

            Functions.vp_data_set(instance, attribute, length, ptr);
            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        /// Converts terrain node data to a 2D TerrainCell array
        /// </summary>
        internal static TerrainCell[,] NodeDataTo2DArray(byte[] data)
        {
            var cells = new TerrainCell[8,8];

            using ( var memStream = new MemoryStream(data) )
            {   
                var      array = new byte[8];
                GCHandle pin   = GCHandle.Alloc(array, GCHandleType.Pinned);

                for (var i = 0; i < 64; i++)
                {
                    // Source: http://geekswithblogs.net/taylorrich/archive/2006/08/21/88665.aspx
                    if ( memStream.Read(array, 0, 8) < 8 )
                        throw new Exception("Unexpected end of byte array");

                    TerrainCell cell = (TerrainCell) Marshal.PtrToStructure( pin.AddrOfPinnedObject(), typeof(TerrainCell) );

                    int x       = i % 8;
                    int z       = (i - x) / 8;
                    cells[x, z] = cell;
                }

                pin.Free();
            }

            return cells;
        }

        /// <summary>
        /// Converts a 2D TerrainCell array to raw VP terrain data
        /// </summary>
        /// <remarks>http://stackoverflow.com/a/650886</remarks>
        internal static byte[] NodeToNodeData(TerrainNode node)
        {
            var data = new byte[512];

            for (var i = 0; i < 64; i++)
            {
                var cell   = node[i];
                var buffer = Marshal.AllocHGlobal(8);
                var array  = new byte[8];
                Marshal.StructureToPtr(cell, buffer, false);
                Marshal.Copy(buffer, data, i * 8, 8);
                Marshal.FreeHGlobal(buffer);
            }

            return data;
        }
    }
}
