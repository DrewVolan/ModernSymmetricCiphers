﻿namespace ModernSymmetricCiphers.Helpers
{
    /// <summary>
    /// Класс-сборник констант.
    /// </summary>
    internal static class AesConstants
    {
        /// <summary>
        /// Константа для метода SubBytes.
        /// </summary>
        internal static byte[][] Sbox = new byte[16][] {
            new byte[16] { 99, 124, 119, 123, 242, 107, 111, 197, 48, 1, 103, 43, 254, 215, 171, 118 },
            new byte[16] { 202, 130, 201, 125, 250, 89, 71, 240, 173, 212, 162, 175, 156, 164, 114, 192 },
            new byte[16] { 183, 253, 147, 38, 54, 63, 247, 204, 52, 165, 229, 241, 113, 216, 49, 21 },
            new byte[16] { 4, 199, 35, 195, 24, 150, 5, 154, 7, 18, 128, 226, 235, 39, 178, 117 },
            new byte[16] { 9, 131, 44, 26, 27, 110, 90, 160, 82, 59, 214, 179, 41, 227, 47, 132 },
            new byte[16] { 83, 209, 0, 237, 32, 252, 177, 91, 106, 203, 190, 57, 74, 76, 88, 207 },
            new byte[16] { 208, 239, 170, 251, 67, 77, 51, 133, 69, 249, 2, 127, 80, 60, 159, 168 },
            new byte[16] { 81, 163, 64, 143, 146, 157, 56, 245, 188, 182, 218, 33, 16, 255, 243, 210 },
            new byte[16] { 205, 12, 19, 236, 95, 151, 68, 23, 196, 167, 126, 61, 100, 93, 25, 115 },
            new byte[16] { 96, 129, 79, 220, 34, 42, 144, 136, 70, 238, 184, 20, 222, 94, 11, 219 },
            new byte[16] { 224, 50, 58, 10, 73, 6, 36, 92, 194, 211, 172, 98, 145, 149, 228, 121 },
            new byte[16] { 231, 200, 55, 109, 141, 213, 78, 169, 108, 86, 244, 234, 101, 122, 174, 8 },
            new byte[16] { 186, 120, 37, 46, 28, 166, 180, 198, 232, 221, 116, 31, 75, 189, 139, 138 },
            new byte[16] { 112, 62, 181, 102, 72, 3, 246, 14, 97, 53, 87, 185, 134, 193, 29, 158 },
            new byte[16] { 225, 248, 152, 17, 105, 217, 142, 148, 155, 30, 135, 233, 206, 85, 40, 223 },
            new byte[16] { 140, 161, 137, 13, 191, 230, 66, 104, 65, 153, 45, 15, 176, 84, 187, 22 } };

        /// <summary>
        /// Константа для инверсии метода SubBytes.
        /// </summary>
        internal static byte[][] InverseSbox = new byte[16][] {
            new byte[16] { 82, 9, 106, 213, 48, 54, 165, 56, 191, 64, 163, 158, 129, 243, 215, 251 },
            new byte[16] { 124, 227, 57, 130, 155, 47, 255, 135, 52, 142, 67, 68, 196, 222, 233, 203 },
            new byte[16] { 84, 123, 148, 50, 166, 194, 35, 61, 238, 76, 149, 11, 66, 250, 195, 78 },
            new byte[16] { 8, 46, 161, 102, 40, 217, 36, 178, 118, 91, 162, 73, 109, 139, 209, 37 },
            new byte[16] { 114, 248, 246, 100, 134, 104, 152, 22, 212, 164, 92, 204, 93, 101, 182, 146 },
            new byte[16] { 108, 112, 72, 80, 253, 237, 185, 218, 94, 21, 70, 87, 167, 141, 157, 132 },
            new byte[16] { 144, 216, 171, 0, 140, 188, 211, 10, 247, 228, 88, 5, 184, 179, 69, 6 },
            new byte[16] { 208, 44, 30, 143, 202, 63, 15, 2, 193, 175, 189, 3, 1, 19, 138, 107 },
            new byte[16] { 58, 145, 17, 65, 79, 103, 220, 234, 151, 242, 207, 206, 240, 180, 230, 115 },
            new byte[16] { 150, 172, 116, 34, 231, 173, 53, 133, 226, 249, 55, 232, 28, 117, 223, 110 },
            new byte[16] { 71, 241, 26, 113, 29, 41, 197, 137, 111, 183, 98, 14, 170, 24, 190, 27 },
            new byte[16] { 252, 86, 62, 75, 198, 210, 121, 32, 154, 219, 192, 254, 120, 205, 90, 244 },
            new byte[16] { 31, 221, 168, 51, 136, 7, 199, 49, 177, 18, 16, 89, 39, 128, 236, 95 },
            new byte[16] { 96, 81, 127, 169, 25, 181, 74, 13, 45, 229, 122, 159, 147, 201, 156, 239 },
            new byte[16] { 160, 224, 59, 77, 174, 42, 245, 176, 200, 235, 187, 60, 131, 83, 153, 97 },
            new byte[16] { 23, 43, 4, 126, 186, 119, 214, 38, 225, 105, 20, 99, 85, 33, 12, 125 } };

        /// <summary>
        /// Константа для метода MixColumn.
        /// </summary>
        internal static byte[][] MixColumnsCoefficients = new byte[4][] {
            new byte[4] { 0x02, 0x03, 0x01, 0x01 },
            new byte[4] { 0x01, 0x02, 0x03, 0x01 },
            new byte[4] { 0x01, 0x01, 0x02, 0x03 },
            new byte[4] { 0x03, 0x01, 0x01, 0x02 } };

        /// <summary>
        /// Константа для инверсии метода MixColumn.
        /// </summary>
        internal static byte[][] InvMixColumnsCoefficients = new byte[4][] {
            new byte[4]{ 0x0e, 0x0b, 0x0d, 0x09 },
            new byte[4]{ 0x09, 0x0e, 0x0b, 0x0d },
            new byte[4]{ 0x0d, 0x09, 0x0e, 0x0b },
            new byte[4]{ 0x0b, 0x0d, 0x09, 0x0e } };

        /// <summary>
        /// Константа для метода AddRoundConstant.
        /// </summary>
        internal static byte[][] RoundConst = new byte[16][] {
            new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x1b, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x36, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x6c, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0xd8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0xab, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x4d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            new byte[8] { 0x9a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };
    }
}