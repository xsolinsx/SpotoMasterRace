using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SpotoMasterRace
{
    static internal class ClassSpotoMasterRace
    {
        #region Tables

        #region Tables and Indexes

        static internal double[,] zTable = new double[70, 10] {
            //         .00    .01    .02    .03    .04    .05    .06    .07    .08    .09
            /*-3.4*/ { .0003, .0003, .0003, .0003, .0003, .0003, .0003, .0003, .0003, .0002 },
            /*-3.3*/ { .0005, .0005, .0005, .0004, .0004, .0004, .0004, .0004, .0004, .0003 },
            /*-3.2*/ { .0007, .0007, .0006, .0006, .0006, .0006, .0006, .0005, .0005, .0005 },
            /*-3.1*/ { .0010, .0009, .0009, .0009, .0008, .0008, .0008, .0008, .0007, .0007 },
            /*-3.0*/ { .0013, .0013, .0013, .0012, .0012, .0011, .0011, .0011, .0010, .0010 },
            /*-2.9*/ { .0019, .0018, .0018, .0017, .0016, .0016, .0015, .0015, .0014, .0014 },
            /*-2.8*/ { .0026, .0025, .0024, .0023, .0023, .0022, .0021, .0021, .0020, .0019 },
            /*-2.7*/ { .0035, .0034, .0033, .0032, .0031, .0030, .0029, .0028, .0027, .0026 },
            /*-2.6*/ { .0047, .0045, .0044, .0043, .0041, .0040, .0039, .0038, .0037, .0036 },
            /*-2.5*/ { .0062, .0060, .0059, .0057, .0055, .0054, .0052, .0051, .0049, .0048 },
            /*-2.4*/ { .0082, .0080, .0078, .0075, .0073, .0071, .0069, .0068, .0066, .0064 },
            /*-2.3*/ { .0107, .0104, .0102, .0099, .0096, .0094, .0091, .0089, .0087, .0084 },
            /*-2.2*/ { .0139, .0136, .0132, .0129, .0125, .0122, .0119, .0116, .0113, .0110 },
            /*-2.1*/ { .0179, .0174, .0170, .0166, .0162, .0158, .0154, .0150, .0146, .0143 },
            /*-2.0*/ { .0228, .0222, .0217, .0212, .0207, .0202, .0197, .0192, .0188, .0183 },
            /*-1.9*/ { .0287, .0281, .0274, .0268, .0262, .0256, .0250, .0244, .0239, .0233 },
            /*-1.8*/ { .0359, .0351, .0344, .0336, .0329, .0322, .0314, .0307, .0301, .0294 },
            /*-1.7*/ { .0446, .0436, .0427, .0418, .0409, .0401, .0392, .0384, .0375, .0367 },
            /*-1.6*/ { .0548, .0537, .0526, .0516, .0505, .0495, .0485, .0475, .0465, .0455 },
            /*-1.5*/ { .0668, .0655, .0643, .0630, .0618, .0606, .0594, .0582, .0571, .0559 },
            /*-1.4*/ { .0808, .0793, .0778, .0764, .0749, .0735, .0721, .0708, .0694, .0681 },
            /*-1.3*/ { .0968, .0951, .0934, .0918, .0901, .0885, .0869, .0853, .0838, .0823 },
            /*-1.2*/ { .1151, .1131, .1112, .1093, .1075, .1056, .1038, .1020, .1003, .0985 },
            /*-1.1*/ { .1357, .1335, .1314, .1292, .1271, .1251, .1230, .1210, .1190, .1170 },
            /*-1.0*/ { .1587, .1562, .1539, .1515, .1492, .1469, .1446, .1423, .1401, .1379 },
            /*-0.9*/ { .1841, .1814, .1788, .1762, .1736, .1711, .1685, .1660, .1635, .1611 },
            /*-0.8*/ { .2119, .2090, .2061, .2033, .2005, .1977, .1949, .1922, .1894, .1867 },
            /*-0.7*/ { .2420, .2389, .2358, .2327, .2296, .2266, .2236, .2206, .2177, .2148 },
            /*-0.6*/ { .2743, .2709, .2676, .2643, .2611, .2578, .2546, .2514, .2483, .2451 },
            /*-0.5*/ { .3085, .3050, .3015, .2981, .2946, .2912, .2877, .2843, .2810, .2776 },
            /*-0.4*/ { .3446, .3409, .3372, .3336, .3300, .3264, .3228, .3192, .3156, .3121 },
            /*-0.3*/ { .3821, .3783, .3745, .3707, .3669, .3632, .3594, .3557, .3520, .3483 },
            /*-0.2*/ { .4207, .4168, .4129, .4090, .4052, .4013, .3974, .3936, .3897, .3859 },
            /*-0.1*/ { .4602, .4562, .4522, .4483, .4443, .4404, .4364, .4325, .4286, .4247 },
            /*-0.0*/ { .5000, .4960, .4920, .4880, .4840, .4801, .4761, .4721, .4681, .4641 },
            /*0.0*/  { .5000, .5040, .5080, .5120, .5160, .5199, .5239, .5279, .5319, .5359 },
            /*0.1*/  { .5398, .5438, .5478, .5517, .5557, .5596, .5636, .5675, .5714, .5753 },
            /*0.2*/  { .5793, .5832, .5871, .5910, .5948, .5987, .6026, .6064, .6103, .6141 },
            /*0.3*/  { .6179, .6217, .6255, .6293, .6331, .6368, .6406, .6443, .6480, .6517 },
            /*0.4*/  { .6554, .6591, .6628, .6664, .6700, .6736, .6772, .6808, .6844, .6879 },
            /*0.5*/  { .6915, .6950, .6985, .7019, .7054, .7088, .7123, .7157, .7190, .7224 },
            /*0.6*/  { .7257, .7291, .7324, .7357, .7389, .7422, .7454, .7486, .7517, .7549 },
            /*0.7*/  { .7580, .7611, .7642, .7673, .7704, .7734, .7764, .7794, .7823, .7852 },
            /*0.8*/  { .7881, .7910, .7939, .7967, .7995, .8023, .8051, .8078, .8106, .8133 },
            /*0.9*/  { .8159, .8186, .8212, .8238, .8264, .8289, .8315, .8340, .8365, .8389 },
            /*1.0*/  { .8413, .8438, .8461, .8485, .8508, .8531, .8554, .8577, .8599, .8621 },
            /*1.1*/  { .8643, .8665, .8686, .8708, .8729, .8749, .8770, .8790, .8810, .8830 },
            /*1.2*/  { .8849, .8869, .8888, .8907, .8925, .8944, .8962, .8980, .8997, .9015 },
            /*1.3*/  { .9032, .9049, .9066, .9082, .9099, .9115, .9131, .9147, .9162, .9177 },
            /*1.4*/  { .9192, .9207, .9222, .9236, .9251, .9265, .9279, .9292, .9306, .9319 },
            /*1.5*/  { .9332, .9345, .9357, .9370, .9382, .9394, .9406, .9418, .9429, .9441 },
            /*1.6*/  { .9452, .9463, .9474, .9484, .9495, .9505, .9515, .9525, .9535, .9545 },
            /*1.7*/  { .9554, .9564, .9573, .9582, .9591, .9599, .9608, .9616, .9625, .9633 },
            /*1.8*/  { .9641, .9649, .9656, .9664, .9671, .9678, .9686, .9693, .9699, .9706 },
            /*1.9*/  { .9713, .9719, .9726, .9732, .9738, .9744, .9750, .9756, .9761, .9767 },
            /*2.0*/  { .9772, .9778, .9783, .9788, .9793, .9798, .9803, .9808, .9812, .9817 },
            /*2.1*/  { .9821, .9826, .9830, .9834, .9838, .9842, .9846, .9850, .9854, .9857 },
            /*2.2*/  { .9861, .9864, .9868, .9871, .9875, .9878, .9881, .9884, .9887, .9890 },
            /*2.3*/  { .9893, .9896, .9898, .9901, .9904, .9906, .9909, .9911, .9913, .9916 },
            /*2.4*/  { .9918, .9920, .9922, .9925, .9927, .9929, .9931, .9932, .9934, .9936 },
            /*2.5*/  { .9938, .9940, .9941, .9943, .9945, .9946, .9948, .9949, .9951, .9952 },
            /*2.6*/  { .9953, .9955, .9956, .9957, .9959, .9960, .9961, .9962, .9963, .9964 },
            /*2.7*/  { .9965, .9966, .9967, .9968, .9969, .9970, .9971, .9972, .9973, .9974 },
            /*2.8*/  { .9974, .9975, .9976, .9977, .9977, .9978, .9979, .9979, .9980, .9981 },
            /*2.9*/  { .9981, .9982, .9982, .9983, .9984, .9984, .9985, .9985, .9986, .9986 },
            /*3.0*/  { .9987, .9987, .9987, .9988, .9988, .9989, .9989, .9989, .9990, .9990 },
            /*3.1*/  { .9990, .9991, .9991, .9991, .9992, .9992, .9992, .9992, .9993, .9993 },
            /*3.2*/  { .9993, .9993, .9994, .9994, .9994, .9994, .9994, .9995, .9995, .9995 },
            /*3.3*/  { .9995, .9995, .9995, .9996, .9996, .9996, .9996, .9996, .9996, .9997 },
            /*3.4*/  { .9997, .9997, .9997, .9997, .9997, .9997, .9997, .9997, .9997, .9998 } };

        static private Dictionary<string, int> zTableRowIndex = new Dictionary<string, int> {
            { "-3.4", 0 }, { "-3.3", 1 }, { "-3.2", 2 }, { "-3.1", 3 }, { "-3.0", 4 },
            { "-2.9", 5 }, { "-2.8", 6 }, { "-2.7", 7 }, { "-2.6", 8 }, { "-2.5", 9 },
            { "-2.4", 10 }, { "-2.3", 11 }, { "-2.2", 12 }, { "-2.1", 13 }, { "-2.0", 14 },
            { "-1.9", 15 }, { "-1.8", 16 }, { "-1.7", 17 }, { "-1.6", 18 }, { "-1.5", 19 },
            { "-1.4", 20 }, { "-1.3", 21 }, { "-1.2", 22 }, { "-1.1", 23 }, { "-1.0", 24 },
            { "-0.9", 25 }, { "-0.8", 26 }, { "-0.7", 27 }, { "-0.6", 28 }, { "-0.5", 29 },
            { "-0.4", 30 }, { "-0.3", 31 }, { "-0.2", 32 }, { "-0.1", 33 }, { "-0.0", 34 },
            { "0.0", 35 }, { "0.1", 36 }, { "0.2", 37 }, { "0.3", 38 }, { "0.4", 39 },
            { "0.5", 40 }, { "0.6", 41 }, { "0.7", 42 }, { "0.8", 43 }, { "0.9", 44 },
            { "1.0", 45 }, { "1.1", 46 }, { "1.2", 47 }, { "1.3", 48 }, { "1.4", 49 },
            { "1.5", 50 }, { "1.6", 51 }, { "1.7", 52 }, { "1.8", 53 }, { "1.9", 54 },
            { "2.0", 55 }, { "2.1", 56 }, { "2.2", 57 }, { "2.3", 58 }, { "2.4", 59 },
            { "2.5", 60 }, { "2.6", 61 }, { "2.7", 62 }, { "2.8", 63 }, { "2.9", 64 },
            { "3.0", 65 }, { "3.1", 66 }, { "3.2", 67 }, { "3.3", 68 }, { "3.4", 69 } };

        static internal double[,] chiSquareTable = new double[37, 10] {
            //        .995    .990    .975    .950    .900    .100     .050     .025     .010     .005
            /*1*/   { 0.000,  0.000,  0.001,  0.004,  0.016,  2.706,   3.841,   5.024,   6.635,   7.879   },
            /*2*/   { 0.010,  0.020,  0.051,  0.103,  0.211,  4.605,   5.991,   7.378,   9.210,   10.597  },
            /*3*/   { 0.072,  0.115,  0.216,  0.352,  0.584,  6.251,   7.815,   9.348,   11.345,  12.838  },
            /*4*/   { 0.207,  0.297,  0.484,  0.711,  1.064,  7.779,   9.488,   11.143,  13.277,  14.860  },
            /*5*/   { 0.412,  0.554,  0.831,  1.145,  1.610,  9.236,   11.070,  12.833,  15.086,  16.750  },
            /*6*/   { 0.676,  0.872,  1.237,  1.635,  2.204,  10.645,  12.592,  14.449,  16.812,  18.548  },
            /*7*/   { 0.989,  1.239,  1.690,  2.167,  2.833,  12.017,  14.067,  16.013,  18.475,  20.278  },
            /*8*/   { 1.344,  1.646,  2.180,  2.733,  3.490,  13.362,  15.507,  17.535,  20.090,  21.955  },
            /*9*/   { 1.735,  2.088,  2.700,  3.325,  4.168,  14.684,  16.919,  19.023,  21.666,  23.589  },
            /*10*/  { 2.156,  2.558,  3.247,  3.940,  4.865,  15.987,  18.307,  20.483,  23.209,  25.188  },
            /*11*/  { 2.603,  3.053,  3.816,  4.575,  5.578,  17.275,  19.675,  21.920,  24.725,  26.757  },
            /*12*/  { 3.074,  3.571,  4.404,  5.226,  6.304,  18.549,  21.026,  23.337,  26.217,  28.300  },
            /*13*/  { 3.565,  4.107,  5.009,  5.892,  7.042,  19.812,  22.362,  24.736,  27.688,  29.819  },
            /*14*/  { 4.075,  4.660,  5.629,  6.571,  7.790,  21.064,  23.685,  26.119,  29.141,  31.319  },
            /*15*/  { 4.601,  5.229,  6.262,  7.261,  8.547,  22.307,  24.996,  27.488,  30.578,  32.801  },
            /*16*/  { 5.142,  5.812,  6.908,  7.962,  9.312,  23.542,  26.296,  28.845,  32.000,  34.267  },
            /*17*/  { 5.697,  6.408,  7.564,  8.672,  10.085, 24.769,  27.587,  30.191,  33.409,  35.718  },
            /*18*/  { 6.265,  7.015,  8.231,  9.390,  10.865, 25.989,  28.869,  31.526,  34.805,  37.156  },
            /*19*/  { 6.844,  7.633,  8.907,  10.117, 11.651, 27.204,  30.144,  32.852,  36.191,  38.582  },
            /*20*/  { 7.434,  8.260,  9.591,  10.851, 12.443, 28.412,  31.410,  34.170,  37.566,  39.997  },
            /*21*/  { 8.034,  8.897,  10.283, 11.591, 13.240, 29.615,  32.671,  35.479,  38.932,  41.401  },
            /*22*/  { 8.643,  9.542,  10.982, 12.338, 14.041, 30.813,  33.924,  36.781,  40.289,  42.796  },
            /*23*/  { 9.260,  10.196, 11.689, 13.091, 14.848, 32.007,  35.172,  38.076,  41.638,  44.181  },
            /*24*/  { 9.886,  10.856, 12.401, 13.848, 15.659, 33.196,  36.415,  39.364,  42.980,  45.559  },
            /*25*/  { 10.520, 11.524, 13.120, 14.611, 16.473, 34.382,  37.652,  40.646,  44.314,  46.928  },
            /*26*/  { 11.160, 12.198, 13.844, 15.379, 17.292, 35.563,  38.885,  41.923,  45.642,  48.290  },
            /*27*/  { 11.808, 12.879, 14.573, 16.151, 18.114, 36.741,  40.113,  43.195,  46.963,  49.645  },
            /*28*/  { 12.461, 13.565, 15.308, 16.928, 18.939, 37.916,  41.337,  44.461,  48.278,  50.993  },
            /*29*/  { 13.121, 14.256, 16.047, 17.708, 19.768, 39.087,  42.557,  45.722,  49.588,  52.336  },
            /*30*/  { 13.787, 14.953, 16.791, 18.493, 20.599, 40.256,  43.773,  46.979,  50.892,  53.672  },
            /*40*/  { 20.707, 22.164, 24.433, 26.509, 29.051, 51.805,  55.758,  59.342,  63.691,  66.766  },
            /*50*/  { 27.991, 29.707, 32.357, 34.764, 37.689, 63.167,  67.505,  71.420,  76.154,  79.490  },
            /*60*/  { 35.534, 37.485, 40.482, 43.188, 46.459, 74.397,  79.082,  83.298,  88.379,  91.952  },
            /*70*/  { 43.275, 45.442, 48.758, 51.739, 55.329, 85.527,  90.531,  95.023,  100.425, 104.215 },
            /*80*/  { 51.172, 53.540, 57.153, 60.391, 64.278, 96.578,  101.879, 106.629, 112.329, 116.321 },
            /*90*/  { 59.196, 61.754, 65.647, 69.126, 73.291, 107.565, 113.145, 118.136, 124.116, 128.299 },
            /*100*/ { 67.328, 70.065, 74.222, 77.929, 82.358, 118.498, 124.342, 129.561, 135.807, 140.169 } };

        static private Dictionary<int, int> chiSquareTableRowIndex = new Dictionary<int, int> {
            { 1, 0 }, { 2, 1 }, { 3, 2 }, { 4, 3 }, { 5, 4 },
            { 6, 5 }, { 7, 6 }, { 8, 7 }, { 9, 8 }, { 10, 9 },
            { 11, 10 }, { 12, 11 }, { 13, 12 }, { 14, 13 }, { 15, 14 },
            { 16, 15 }, { 17, 16 }, { 18, 17 }, { 19, 18 }, { 20, 19 },
            { 21, 20 }, { 22, 21 }, { 23, 22 }, { 24, 23 }, { 25, 24 },
            { 26, 25 }, { 27, 26 }, { 28, 27 }, { 29, 28 }, { 30, 29 },
            { 40, 30 }, { 50, 31 }, { 60, 32 }, { 70, 33 }, { 80, 34 },
            { 90, 35 }, { 100, 36 } };

        static private Dictionary<double, int> chiSquareTableColumnIndex = new Dictionary<double, int> {
            { 0.995, 0 }, { 0.990, 1 }, { 0.975, 2 }, { 0.950, 3 }, { 0.900, 4 },
            { 0.100, 5 }, { 0.050, 6 }, { 0.025, 7 }, { 0.010, 8 }, { 0.005, 9 } };

        static internal double[,] tTable = new double[35, 5] {
            //       0.100  0.050  0.025   0.010    0.005
            /*1*/  { 3.078, 6.314, 12.706, 31.821, 63.657 },
            /*2*/  { 1.886, 2.920, 4.303,  6.965,  9.925  },
            /*3*/  { 1.638, 2.353, 3.182,  4.541,  5.841  },
            /*4*/  { 1.533, 2.132, 2.776,  3.747,  4.604  },
            /*5*/  { 1.476, 2.015, 2.571,  3.365,  4.032  },
            /*6*/  { 1.440, 1.943, 2.447,  3.143,  3.707  },
            /*7*/  { 1.415, 1.895, 2.365,  2.998,  3.499  },
            /*8*/  { 1.397, 1.860, 2.306,  2.896,  3.355  },
            /*9*/  { 1.383, 1.833, 2.262,  2.821,  3.250  },
            /*10*/ { 1.372, 1.812, 2.228,  2.764,  3.169  },
            /*11*/ { 1.363, 1.796, 2.201,  2.718,  3.106  },
            /*12*/ { 1.356, 1.782, 2.179,  2.681,  3.055  },
            /*13*/ { 1.350, 1.771, 2.160,  2.650,  3.012  },
            /*14*/ { 1.345, 1.761, 2.145,  2.624,  2.977  },
            /*15*/ { 1.341, 1.753, 2.131,  2.602,  2.947  },
            /*16*/ { 1.337, 1.746, 2.120,  2.583,  2.921  },
            /*17*/ { 1.333, 1.740, 2.110,  2.567,  2.898  },
            /*18*/ { 1.330, 1.734, 2.101,  2.552,  2.878  },
            /*19*/ { 1.328, 1.729, 2.093,  2.539,  2.861  },
            /*20*/ { 1.325, 1.725, 2.086,  2.528,  2.845  },
            /*21*/ { 1.323, 1.721, 2.080,  2.518,  2.831  },
            /*22*/ { 1.321, 1.717, 2.074,  2.508,  2.819  },
            /*23*/ { 1.319, 1.714, 2.069,  2.500,  2.807  },
            /*24*/ { 1.318, 1.711, 2.064,  2.492,  2.797  },
            /*25*/ { 1.316, 1.708, 2.060,  2.485,  2.787  },
            /*26*/ { 1.315, 1.706, 2.056,  2.479,  2.779  },
            /*27*/ { 1.314, 1.703, 2.052,  2.473,  2.771  },
            /*28*/ { 1.313, 1.701, 2.048,  2.467,  2.763  },
            /*29*/ { 1.311, 1.699, 2.045,  2.462,  2.756  },
            /*30*/ { 1.310, 1.697, 2.042,  2.457,  2.750  },
            /*32*/ { 1.309, 1.694, 2.037,  2.449,  2.738  },
            /*34*/ { 1.307, 1.691, 2.032,  2.441,  2.728  },
            /*36*/ { 1.306, 1.688, 2.028,  2.434,  2.719  },
            /*38*/ { 1.304, 1.686, 2.024,  2.429,  2.712  },
            /*∞*/  { 1.282, 1.645, 1.960,  2.326,  2.576  } };

        static private Dictionary<string, int> tTableRowIndex = new Dictionary<string, int> {
            { "1", 0 }, { "2", 1 }, { "3", 2 }, { "4", 3 }, { "5", 4 },
            { "6", 5 }, { "7", 6 }, { "8", 7 }, { "9", 8 }, { "10", 9 },
            { "11", 10 }, { "12", 11 }, { "13", 12 }, { "14", 13 }, { "15", 14 },
            { "16", 15 }, { "17", 16 }, { "18", 17 }, { "19", 18 }, { "20", 19 },
            { "21", 20 }, { "22", 21 }, { "23", 22 }, { "24", 23 }, { "25", 24 },
            { "26", 25 }, { "27", 26 }, { "28", 27 }, { "29", 28 }, { "30", 29 },
            { "32", 30 }, { "34", 31 }, { "36", 32 }, { "38", 33 }, { "∞", 34 },
            //∞
            { "", 34 } };

        static private Dictionary<double, int> tTableColumnIndex = new Dictionary<double, int> { { 0.100, 0 }, { 0.050, 1 }, { 0.025, 2 }, { 0.010, 3 }, { 0.005, 4 } };

        #endregion Tables and Indexes

        #region Usage

        static internal double GetZTableProbability(string zPoint)
        {
            string firstPart = zPoint.Substring(0, 3); //x.xo
            string secondPart = zPoint.Substring(3, 1); //o.ox
            return zTable[zTableRowIndex[firstPart], Convert.ToInt32(secondPart)];
        }

        static internal double GetZTableZPoint(double probabilityValue)
        {
            List<string> keys = new List<string>(zTableRowIndex.Keys);
            List<int> values = new List<int>(zTableRowIndex.Values);
            double currProb;
            double bestProb = Int32.MaxValue;
            string iString = "";
            string jString = "";
            string firstPart = "";
            for (int i = 0; i < zTable.GetLength(0); i++)
                for (int j = 0; j < zTable.GetLength(1); j++)
                {
                    currProb = zTable[i, j];
                    if (Math.Abs(probabilityValue - bestProb) >= Math.Abs(probabilityValue - currProb))
                    {
                        bestProb = currProb;
                        for (int k = 0; k < keys.Count; k++)
                            if (zTable[values[k], j] == bestProb)
                                iString = keys[k];
                        jString = j.ToString();
                    }
                }
            return Convert.ToDouble(iString + jString);
        }

        static internal double GetChiSquareTableValue(int degreesOfFreedom, double alpha)
        { return chiSquareTable[chiSquareTableRowIndex[degreesOfFreedom], chiSquareTableColumnIndex[alpha]]; }

        static internal double GetTTableValue(string degreesOfFreedom, double alpha)
        { return tTable[tTableRowIndex[degreesOfFreedom], tTableColumnIndex[alpha]]; }

        #endregion Usage

        #endregion Tables

        #region Utilities

        static public BindingList<T> RemoveDuplicates<T>(BindingList<T> collection)
        {
            BindingList<T> list = new BindingList<T>();
            foreach (T item in collection)
                if (!list.Contains(item))
                    list.Add(item);
            return list;
        }

        static internal List<T> RemoveDuplicates<T>(List<T> collection)
        {
            List<T> list = new List<T>();
            foreach (T item in collection)
                if (!list.Contains(item))
                    list.Add(item);
            return list;
        }

        static internal int GetFrequency(List<string> collection, string item)
        {
            int counter = 0;
            foreach (string obj in collection)
                if (obj == item)
                    counter++;
            return counter;
        }

        static internal int GetFrequency(List<double> collection, double item)
        {
            List<string> list = new List<string>();
            foreach (double obj in collection)
                list.Add(obj.ToString());
            return GetFrequency(list, item.ToString());
        }

        static internal double Sum(List<double> collection)
        {
            double sum = 0;
            foreach (double item in collection)
                sum += item;
            return sum;
        }

        static internal int GetFrequency(BindingList<StructSet<string>> sets, StructSet<string> container)
        {
            int counter = 0;
            List<int> countedElementsIndeces = new List<int>();
            for (int i = 0; i < container.Cardinality; i++)
                foreach (StructSet<string> interestingSet in sets)
                    foreach (string elementInTheSet in interestingSet.Elements)
                        if (elementInTheSet == container.Elements[i])
                        {
                            if (!countedElementsIndeces.Contains(i))
                                countedElementsIndeces.Add(i);
                            bool counted = false;
                            foreach (int index in countedElementsIndeces)
                                if (container.Elements[i] == container.Elements[index] && i != index)
                                    counted = true;
                            if (!counted)
                                counter++;
                        }
            return counter;
        }

        #endregion Utilities

        #region Set Theory

        static internal bool Inclusion(StructSet<string> set1, StructSet<string> set2, bool strict)
        {
            if (set1.Cardinality > set2.Cardinality)
                return false;

            if (strict)
                if (set1 == set2)
                    return false;

            for (int i = 0; i < set1.Cardinality; i++)
                if (!set2.Elements.Contains(set1.Elements[i]))
                    return false;
            return true;
        }

        static internal BindingList<string> PowerSet(StructSet<string> set)
        {
            int n = set.Cardinality;
            // Power set contains 2^N subsets.
            long powerSetCount = Convert.ToInt64(Math.Pow(2, n));
            BindingList<string> powerSet = new BindingList<string>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                string s = "{";
                for (int i = 0; i < n; i++)
                {
                    // Checking whether i'th element of input collection should go to the current subset.
                    if ((setMask & (1 << i)) > 0)
                        s += set.Elements[i] + ",";
                }
                //remove last inserted comma
                try
                { s = s.Remove(s.LastIndexOf(','), 1); }
                catch { }
                s += "}";
                powerSet.Add(s.ToString());
            }
            return powerSet;
        }

        static internal BindingList<StructSet<T>> PowerSet<T>(StructSet<T> set)
        {
            int n = set.Cardinality;
            // Power set contains 2^N subsets.
            long powerSetCount = Convert.ToInt64(Math.Pow(2, n));
            BindingList<StructSet<T>> powerSet = new BindingList<StructSet<T>>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                StructSet<T> s = new StructSet<T>('X');
                for (int i = 0; i < n; i++)
                {
                    // Checking whether i'th element of input collection should go to the current subset.
                    if ((setMask & (1 << i)) > 0)
                        s.Elements.Add(set.Elements[i]);
                }
                powerSet.Add(s);
            }
            return powerSet;
        }

        static internal BindingList<string> Union(StructSet<string> set1, StructSet<string> set2)
        {
            BindingList<string> tempElements = new BindingList<string>();
            foreach (string item in set1.Elements)
                tempElements.Add(item);
            foreach (string item in set2.Elements)
                tempElements.Add(item);
            if (!set1.Ordered)
                tempElements = ClassSpotoMasterRace.RemoveDuplicates(tempElements);
            return tempElements;
        }

        static internal BindingList<string> Intersection(StructSet<string> set1, StructSet<string> set2)
        {
            BindingList<string> tempElements = new BindingList<string>();
            foreach (string item1 in set1.Elements)
                foreach (string item2 in set2.Elements)
                    if (item1 == item2)
                        tempElements.Add(item1);
            if (!set1.Ordered)
                tempElements = ClassSpotoMasterRace.RemoveDuplicates(tempElements);
            return tempElements;
        }

        static internal BindingList<string> Difference(StructSet<string> set1, StructSet<string> set2)
        {
            StructSet<string> intersection = new StructSet<string>('A', Intersection(set1, set2), set1.Ordered);
            BindingList<string> tempElements = new BindingList<string>();
            foreach (string item in set1.Elements)
                tempElements.Add(item);
            foreach (string item in intersection.Elements)
                while (tempElements.IndexOf(item) >= 0)
                    tempElements.Remove(item);
            if (!set1.Ordered)
                tempElements = ClassSpotoMasterRace.RemoveDuplicates(tempElements);
            return tempElements;
        }

        static internal BindingList<string> CartesianProduct(StructSet<string> set1, StructSet<string> set2)
        {
            BindingList<string> tempElements = new BindingList<string>();
            foreach (string item1 in set1.Elements)
                foreach (string item2 in set2.Elements)
                    tempElements.Add("(" + item1 + "," + item2 + ")");
            if (!set1.Ordered)
                tempElements = ClassSpotoMasterRace.RemoveDuplicates(tempElements);
            return tempElements;
        }

        #endregion Set Theory

        #region Descriptive Statistics

        #region Significant Statistics for Nominal Scales

        static internal List<string> Mode(List<string> collection)
        {
            List<string> list = new List<string>(collection);

            List<string> mode = new List<string>();
            int modeFrequency = 0;
            int itemFrequency = 0;
            //find the higher frequency
            foreach (string item in list)
            {
                itemFrequency = GetFrequency(list, item);
                if (itemFrequency > modeFrequency)
                    modeFrequency = itemFrequency;
            }
            //find the mode
            foreach (string item in list)
            {
                itemFrequency = GetFrequency(list, item);
                if (itemFrequency == modeFrequency)
                    if (!mode.Contains(item))
                        mode.Add(item);
            }
            return mode;
        }

        static internal int NumberOfEquivalentClasses<T>(List<T> collection)
        { return RemoveDuplicates(collection).Count; }

        #endregion Significant Statistics for Nominal Scales

        #region Significant Statistics for Ordinal Scales

        static internal Dictionary<double, double> Proportions(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list = RemoveDuplicates(list);
            list.Sort();
            Dictionary<double, double> keyvalue = new Dictionary<double, double>(list.Count);
            for (int i = 0; i < list.Count; i++)
                keyvalue[list[i]] = GetFrequency(collection, list[i]);
            int dim = keyvalue.Count;
            Dictionary<double, double> proportions = new Dictionary<double, double>();
            foreach (KeyValuePair<double, double> keyvaluepair in keyvalue)
                proportions.Add(keyvaluepair.Key, keyvaluepair.Value / collection.Count);
            return proportions;
        }

        static internal Dictionary<double, double> ProportionsPercentages(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list = RemoveDuplicates(list);
            list.Sort();
            Dictionary<double, double> keyvalue = new Dictionary<double, double>(list.Count);
            for (int i = 0; i < list.Count; i++)
                keyvalue[list[i]] = GetFrequency(collection, list[i]);
            int dim = keyvalue.Count;
            Dictionary<double, double> proportions = Proportions(collection);
            foreach (KeyValuePair<double, double> keyvaluepair in keyvalue)
                proportions[keyvaluepair.Key] = (keyvaluepair.Value / collection.Count) * 100;
            return proportions;
        }

        static internal Dictionary<double, int> CumulativeFrequencies(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list = RemoveDuplicates(list);
            list.Sort();
            Dictionary<double, int> keyvalue = new Dictionary<double, int>(list.Count);
            for (int i = 0; i < list.Count; i++)
                keyvalue[list[i]] = GetFrequency(collection, list[i]);
            double[] keys = new double[keyvalue.Keys.Count];
            keyvalue.Keys.CopyTo(keys, 0);
            for (int i = 0; i < keys.Length; i++)
                keyvalue[keys[i]] += (i - 1 < 0 ? 0 : keyvalue[keys[i - 1]]);
            return keyvalue;
        }

        static internal Dictionary<double, double> CumulativeFrequenciesPercentages(List<double> collection)
        {
            Dictionary<double, int> keyvalue = CumulativeFrequencies(collection);
            int dim = keyvalue.Count;
            Dictionary<double, double> keypercentage = new Dictionary<double, double>();
            foreach (KeyValuePair<double, int> keyvaluepair in keyvalue)
                keypercentage.Add(keyvaluepair.Key, (keyvaluepair.Value * 100) / collection.Count);
            return keypercentage;
        }

        static internal double[] MedianOrdinal(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            if (list.Count % 2 == 0)
                //even
                return new double[] { list[(list.Count / 2) - 1],
                    list[((list.Count / 2) + 1) -1] };
            else
                //odd
                return new double[] { list[((list.Count + 1) / 2) - 1] };
        }

        static internal double[] Quartiles(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            return new double[] {
                Math.Floor(Convert.ToDouble(((1.0 / 4.0) * (list.Count + 1)) - 1)) < 0 ? list[0] : list[Convert.ToInt32(Math.Floor(Convert.ToDouble(((1.0 / 4.0) * (list.Count + 1)) - 1)))],
                Math.Floor(Convert.ToDouble(((2.0 / 4.0) * (list.Count + 1)) - 1)) < 0 ? list[0] : list[Convert.ToInt32(Math.Floor(Convert.ToDouble(((2.0 / 4.0) * (list.Count + 1)) - 1)))],
                Math.Floor(Convert.ToDouble(((3.0 / 4.0) * (list.Count + 1)) - 1)) < 0 ? list[0] : list[Convert.ToInt32(Math.Floor(Convert.ToDouble(((3.0 / 4.0) * (list.Count + 1)) - 1)))] };
        }

        static internal double XPercentile(List<double> collection, short xpercentile)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            int index = Convert.ToInt32(Math.Floor(((double)list.Count * ((double)xpercentile % 100.0)) / 100.0));
            return list[index <= 0 ? 0 : (index - 1)];
        }

        static internal double PercentileRank(List<double> collection, double key)
        {
            Dictionary<double, int> dict = CumulativeFrequencies(collection);
            if (dict.ContainsKey(key))
                return (dict[key] / (double)collection.Count) * 100.0;
            else
                return 0;
        }

        #endregion Significant Statistics for Ordinal Scales

        #region Significant Statistics for Interval and Ratio Scales

        static internal double Mean(List<double> collection)
        { return Sum(collection) / collection.Count; }

        static internal double MedianInterval(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            if (list.Count % 2 == 0)
                //even
                return Mean(new List<double>(new double[] { list[(list.Count / 2) - 1], list[((list.Count / 2) + 1) - 1] }));
            else
                //odd
                return list[((list.Count + 1) / 2) - 1];
        }

        static internal double Range(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            return list[list.Count - 1] - list[0];
        }

        static internal double InterquartileDifference(List<double> collection)
        {
            double[] quartiles = Quartiles(collection);
            return quartiles[2] - quartiles[0];
        }

        static internal double Deviance(List<double> collection)
        {
            double sumOfSquares = 0;
            double mean = Mean(collection);
            foreach (double item in collection)
                sumOfSquares += Math.Pow(item - mean, 2);
            return sumOfSquares;
        }

        static internal double Deviance(List<double> collection, double mean)
        {
            double sumOfSquares = 0;
            foreach (double item in collection)
                sumOfSquares += Math.Pow(item - mean, 2);
            return sumOfSquares;
        }

        static internal double VariancePopulation(List<double> collection)
        { return Deviance(collection) / collection.Count; }

        static internal double VariancePopulation(double deviance, int n)
        { return deviance / n; }

        static internal double VarianceSample(List<double> collection)
        { return Deviance(collection) / (collection.Count - 1); }

        static internal double VarianceSample(double deviance, int n)
        { return deviance / (n - 1); }

        static internal double StandardDeviationPopulation(List<double> collection)
        { return Math.Sqrt(VariancePopulation(collection)); }

        static internal double StandardDeviationSample(List<double> collection)
        { return Math.Sqrt(VarianceSample(collection)); }

        static internal double StandardDeviation(double variance)
        { return Math.Sqrt(variance); }

        static internal double CoefficientOfVariationPopulation(List<double> collection)
        { return StandardDeviationPopulation(collection) / Math.Abs(Mean(collection)); }

        static internal double CoefficientOfVariationPopulation(double standardDeviationPopulation, double mean)
        { return standardDeviationPopulation / Math.Abs(mean); }

        static internal double CoefficientOfVariationSample(List<double> collection)
        { return StandardDeviationSample(collection) / Math.Abs(Mean(collection)); }

        static internal double CoefficientOfVariationSample(double standardDeviationSample, double mean)
        { return standardDeviationSample / Math.Abs(mean); }

        static internal double ZScore(List<double> collection, double item)
        { return (item - Mean(collection)) / StandardDeviationPopulation(collection); }

        static internal double ZScore(double mean, double standardDeviation, double item)
        { return (item - mean) / standardDeviation; }

        static internal double TScore(double zscore, double mean, double standardDeviation)
        { return mean + zscore * standardDeviation; }

        #endregion Significant Statistics for Interval and Ratio Scales

        #endregion Descriptive Statistics

        #region Combinatorics

        static internal double FactorialOf(short n)
        {
            double fact = 1;
            for (short i = n; i > 0; i--)
                fact *= i;
            return fact;
        }

        static internal double BinomialCoefficient(short n, short k)
        { return FactorialOf(n) / (FactorialOf(k) * FactorialOf(Convert.ToInt16(n - k))); }

        #endregion Combinatorics

        #region Probability Distributions

        static internal StructSet<StructSet<string>> MainEvents(BindingList<StructSet<string>> sets)
        {
            StructSet<StructSet<string>> mainEvents = new StructSet<StructSet<string>>('X');
            foreach (StructSet<string> set in sets)
            {
                bool alreadyPresent = false;
                foreach (StructSet<string> ev in mainEvents.Elements)
                    if (set.Cardinality == ev.Cardinality)
                        alreadyPresent = true;
                if (!alreadyPresent)
                    mainEvents.Elements.Add(set);
            }
            return mainEvents;
        }

        #endregion Probability Distributions

        #region Parametric Distributions

        #region Discrete

        static internal double[] BinomialDistribution(short n, double p)
        {
            double[] probabilities = new double[n];
            for (short i = 0; i < probabilities.Length; i++)
                probabilities[i] = BinomialCoefficient(n, i) * Math.Pow(p, i) * Math.Pow((1 - p), n - i);
            return probabilities;
        }

        static internal double[] HypergeometricDistribution(short Q, short q, short n)
        {
            double[] probabilities = new double[n];
            for (short i = 0; i < probabilities.Length; i++)
                probabilities[i] = FactorialOf(n) * BinomialCoefficient(q, i) * BinomialCoefficient(Convert.ToInt16(Q - q), Convert.ToInt16(n - i)) * (FactorialOf(Convert.ToInt16(Q - n)) / FactorialOf(Q));
            return probabilities;
        }

        #endregion Discrete

        #region Continuous

        static internal double NormalDistributionValue(double value, double mean, double variance)
        { return (1 / (Math.Sqrt(variance) * Math.Sqrt(2 * Math.PI))) * Math.Pow(Math.E, -(Math.Pow((value - mean), 2) / (2 * variance))); }

        #endregion Continuous

        #endregion Parametric Distributions

        #region Covariance and Correlation

        static internal double Covariance(List<double> firstVariable, List<double> secondVariable)
        {
            if (firstVariable == null || secondVariable == null)
                return Double.NaN;
            double meanFirstVariable = Mean(firstVariable);
            double meanSecondVariable = Mean(secondVariable);
            List<double> listOfProducts = new List<double>();
            for (int i = 0; i < firstVariable.Count; i++)
                listOfProducts.Add((firstVariable[i] - meanFirstVariable) * (secondVariable[i] - meanSecondVariable));
            return Sum(listOfProducts) / (firstVariable.Count - 1);
        }

        static internal double Correlation(List<double> firstVariable, List<double> secondVariable)
        {
            if (firstVariable == null || secondVariable == null)
                return Double.NaN;
            return Covariance(firstVariable, secondVariable) / (StandardDeviationSample(firstVariable) * StandardDeviationSample(secondVariable));
        }

        #endregion Covariance and Correlation
    }
}