
////////////////////////////////////////
//                                     //
//   Generated by CEO's YAAAG - Ver 2  //
// (Yet Another Arya Addon Generator)  //
//    Modified by Hammerhand for       //
//      SA & High Seas content         //
//                                     //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ChapellefixAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {9963, 6, 3, 28}, {9963, 5, 3, 28}, {9963, 5, 2, 30}// 1	2	3	
			, {9963, 5, 1, 30}, {10548, 6, 2, 28}, {10536, 5, 0, 31}// 4	5	6	
			, {10548, 5, 1, 31}, {10548, 5, 1, 31}, {10536, 6, 1, 28}// 7	8	9	
			, {10536, 6, 0, 28}, {10536, 7, 1, 25}, {10536, 7, 0, 25}// 10	11	12	
			, {10536, 7, 2, 25}, {10536, 7, 1, 6}, {10548, 7, 3, 25}// 13	14	15	
			, {149, 6, 2, 10}, {149, 7, 1, 10}, {151, 7, 1, 10}// 16	17	18	
			, {1195, 6, 0, 10}, {1195, 6, 1, 10}, {1872, 6, 0, 5}// 19	20	21	
			, {12789, 5, 8, 7}, {2186, 5, 8, 7}, {2187, 6, 4, 7}// 22	23	24	
			, {2187, 6, 5, 7}, {2187, 6, 7, 7}, {2146, 6, 8, 7}// 25	26	27	
			, {144, 6, 3, 10}, {1195, 7, 1, 10}, {1194, 7, 0, 10}// 28	29	30	
			, {1872, 7, 1, 5}, {1872, 7, 0, 5}, {1854, 8, 1, 6}// 31	32	33	
			, {1850, 8, 0, 6}, {1201, 6, 3, 10}, {1199, 6, 3, 10}// 34	35	36	
			, {1199, 6, 2, 10}, {1196, 5, 3, 10}, {1196, 5, 2, 10}// 37	38	39	
			, {1196, 5, 1, 10}, {1196, 5, 0, 10}, {145, 5, 3, 10}// 40	41	42	
			, {1198, 5, 3, 10}, {1872, 6, 3, 5}, {1872, 6, 3, 5}// 43	44	45	
			, {1872, 6, 2, 5}, {1872, 6, 1, 5}, {1872, 5, 3, 5}// 46	47	48	
			, {1872, 5, 3, 5}, {1872, 5, 2, 5}, {1872, 5, 1, 5}// 49	50	51	
			, {1872, 5, 0, 5}, {10536, 5, -1, 31}, {10536, 5, -2, 31}// 52	53	54	
			, {10547, 6, -4, 31}, {10547, 5, -3, 31}, {10547, 5, -4, 31}// 55	56	57	
			, {10536, 6, -1, 28}, {10536, 6, -2, 28}, {10547, 6, -3, 28}// 58	59	60	
			, {10547, 6, -4, 28}, {10536, 7, -1, 25}, {10536, 7, -2, 25}// 61	62	63	
			, {10536, 7, -3, 25}, {10536, 7, -4, 25}, {10540, 7, -4, 28}// 64	65	66	
			, {10540, 6, -4, 28}, {10540, 5, -4, 28}, {10536, 7, -4, 25}// 67	68	69	
			, {10547, 7, -5, 25}, {10540, 6, -5, 25}, {10540, 5, -5, 6}// 70	71	72	
			, {10540, 5, -5, 25}, {150, 7, -2, 10}, {151, 7, -3, 10}// 73	74	75	
			, {146, 6, -3, 10}, {146, 6, -4, 10}, {1850, 8, -1, 6}// 76	77	78	
			, {1872, 7, -1, 5}, {1193, 7, -1, 10}, {1194, 7, -2, 10}// 79	80	81	
			, {1872, 7, -2, 5}, {1855, 8, -2, 6}, {1195, 6, -1, 10}// 82	83	84	
			, {1195, 6, -2, 10}, {1195, 5, -1, 10}, {1195, 5, -2, 10}// 85	86	87	
			, {1872, 6, -1, 5}, {1872, 6, -2, 5}, {1872, 5, -1, 5}// 88	89	90	
			, {1872, 5, -2, 5}, {1199, 6, -3, 10}, {1199, 6, -4, 10}// 91	92	93	
			, {1203, 6, -4, 10}, {1196, 5, -3, 10}, {1196, 5, -4, 10}// 94	95	96	
			, {145, 5, -5, 10}, {1200, 5, -4, 10}, {151, 6, -5, 10}// 97	98	99	
			, {1872, 6, -3, 5}, {1872, 6, -4, 5}, {1872, 6, -4, 5}// 100	101	102	
			, {1872, 5, -3, 5}, {1872, 5, -4, 5}, {1872, 5, -4, 5}// 103	104	105	
			, {9947, -2, 6, 31}, {9947, -2, 5, 31}, {10548, -2, 7, 28}// 106	107	108	
			, {9947, -1, 6, 25}, {9947, -1, 5, 28}, {1195, 4, 0, 38}// 109	110	111	
			, {1195, 3, 0, 38}, {9958, -3, 6, 28}, {10549, 3, 0, 59}// 112	113	114	
			, {10548, 4, 0, 59}, {9946, -4, 5, 34}, {9946, -4, 4, 34}// 115	116	117	
			, {9946, -4, 4, 34}, {10536, -3, 5, 31}, {10536, -3, 4, 31}// 118	119	120	
			, {21, 2, 0, 57}, {22, 3, 0, 57}, {20, 4, 0, 57}// 121	122	123	
			, {10536, -3, 3, 10}, {10536, -3, 2, 10}, {10536, -4, 2, 10}// 124	125	126	
			, {10536, -5, 6, 10}, {10536, -5, 5, 10}, {10536, -5, 4, 10}// 127	128	129	
			, {10536, -5, 2, 10}, {10538, -5, 5, 33}, {10538, -5, 4, 33}// 130	131	132	
			, {9963, -2, 3, 30}, {9963, -2, 2, 30}, {9963, -3, 3, 30}// 133	134	135	
			, {9963, -3, 2, 30}, {9963, -4, 3, 30}, {9963, -4, 2, 30}// 136	137	138	
			, {9963, -5, 3, 30}, {9963, -5, 2, 30}, {9963, -6, 2, 30}// 139	140	141	
			, {9963, -4, 6, 31}, {9963, -5, 6, 31}, {9963, -6, 6, 30}// 142	143	144	
			, {9963, -6, 5, 30}, {9963, -3, 7, 31}, {9963, -4, 7, 31}// 145	146	147	
			, {9963, -5, 7, 31}, {9963, -6, 7, 31}, {10536, -2, 5, 28}// 148	149	150	
			, {10536, -2, 4, 28}, {10536, -1, 7, 25}, {10536, -1, 5, 25}// 151	152	153	
			, {10536, -1, 4, 25}, {9963, -2, 8, 28}, {9963, -3, 8, 28}// 154	155	156	
			, {9963, -4, 8, 28}, {9963, -5, 8, 28}, {9963, -6, 8, 28}// 157	158	159	
			, {9, 2, 0, 40}, {9, 4, 0, 40}, {17, 2, 0, 37}// 160	161	162	
			, {18, 3, 0, 37}, {16, 4, 0, 37}, {9963, 4, 3, 28}// 163	164	165	
			, {9963, 3, 3, 28}, {9963, 2, 3, 28}, {9963, 1, 3, 28}// 166	167	168	
			, {9963, 0, 3, 28}, {9963, -1, 3, 28}, {9963, -2, 3, 28}// 169	170	171	
			, {9963, -4, 2, 33}, {9963, 4, 2, 30}, {9963, 4, 1, 30}// 172	173	174	
			, {9963, 3, 2, 30}, {9963, 3, 1, 30}, {9963, 2, 2, 30}// 175	176	177	
			, {9963, 2, 1, 30}, {9963, 1, 2, 30}, {9963, 1, 1, 30}// 178	179	180	
			, {9963, 0, 2, 30}, {9963, 0, 1, 30}, {9963, -1, 2, 30}// 181	182	183	
			, {9963, -1, 1, 30}, {9963, -2, 2, 30}, {9963, -2, 1, 30}// 184	185	186	
			, {9963, -3, 2, 30}, {9963, -3, 1, 30}, {9963, -4, 2, 30}// 187	188	189	
			, {9963, -4, 1, 30}, {9963, -6, 2, 30}, {9963, 4, 1, 34}// 190	191	192	
			, {9963, 3, 1, 34}, {9963, 2, 1, 34}, {9963, 1, 1, 34}// 193	194	195	
			, {9963, 0, 1, 34}, {9963, -1, 1, 34}, {9963, -2, 1, 34}// 196	197	198	
			, {9963, -3, 1, 34}, {9963, -4, 1, 34}, {9963, 2, 0, 37}// 199	200	201	
			, {9963, 1, 0, 37}, {9963, 0, 0, 37}, {9963, -1, 0, 37}// 202	203	204	
			, {9963, -2, 0, 37}, {9963, -3, 0, 37}, {10549, -4, 0, 34}// 205	206	207	
			, {10538, -6, 3, 34}, {10538, -5, 5, 31}, {10538, -6, 5, 31}// 208	209	210	
			, {10538, -6, 4, 31}, {10538, -6, 2, 31}, {10538, -5, 1, 34}// 211	212	213	
			, {10538, -5, 0, 31}, {10549, -5, 1, 31}, {10538, -6, 3, 28}// 214	215	216	
			, {10538, -6, 2, 28}, {10538, -6, 1, 28}, {10538, -6, 0, 28}// 217	218	219	
			, {10544, -3, 6, 28}, {10538, -5, 5, 31}, {10536, -3, 6, 28}// 220	221	222	
			, {10548, -3, 6, 31}, {10538, -6, 5, 28}, {10538, -6, 4, 28}// 223	224	225	
			, {10538, -7, 3, 25}, {10538, -7, 2, 25}, {10538, -7, 1, 25}// 226	227	228	
			, {10538, -7, 0, 25}, {10538, -6, 7, 28}, {10538, -6, 6, 28}// 229	230	231	
			, {10538, -6, 5, 28}, {10538, -6, 7, 28}, {10538, -7, 8, 25}// 232	233	234	
			, {10538, -7, 7, 25}, {10538, -7, 6, 25}, {10538, -7, 5, 25}// 235	236	237	
			, {10538, -7, 4, 25}, {10538, -7, 3, 25}, {10549, -7, 8, 25}// 238	239	240	
			, {10548, -1, 8, 25}, {146, -1, 4, 10}, {145, 0, 3, 10}// 241	242	243	
			, {12789, 4, 8, 7}, {12789, 3, 8, 7}, {12789, 2, 8, 7}// 244	245	246	
			, {12789, 1, 8, 7}, {12789, 0, 8, 7}, {2186, 4, 8, 7}// 247	248	249	
			, {2186, 3, 8, 7}, {2186, 2, 8, 7}, {2186, 1, 8, 7}// 250	251	252	
			, {2186, 0, 8, 7}, {1872, 4, 0, 5}, {1872, 4, 1, 5}// 253	254	255	
			, {1872, 4, 2, 5}, {1872, 4, 3, 5}, {1872, 4, 3, 5}// 256	257	258	
			, {1872, 4, 0, 5}, {1872, 4, 1, 5}, {1872, 4, 2, 5}// 259	260	261	
			, {1872, 4, 3, 5}, {1872, 4, 3, 5}, {1198, 4, 3, 10}// 262	263	264	
			, {1198, 4, 3, 10}, {1196, 4, 0, 10}, {1196, 4, 1, 10}// 265	266	267	
			, {1196, 4, 2, 10}, {1196, 4, 3, 10}, {1196, 4, 0, 10}// 268	269	270	
			, {1196, 4, 1, 10}, {1196, 4, 2, 10}, {1196, 4, 3, 10}// 271	272	273	
			, {165, -7, 6, 10}, {1196, -4, 6, 10}, {1872, -4, 6, 5}// 274	275	276	
			, {164, -2, 8, 10}, {165, -1, 6, 10}, {155, -1, 6, 10}// 277	278	279	
			, {164, -5, 8, 10}, {155, -7, 6, 10}, {154, -2, 8, 10}// 280	281	282	
			, {154, -5, 8, 10}, {145, -2, 3, 10}, {150, -7, 8, 10}// 283	284	285	
			, {144, -1, 8, 10}, {146, -1, 7, 10}, {146, -1, 5, 10}// 286	287	288	
			, {1196, -1, 8, 10}, {1196, -1, 7, 10}, {1196, -1, 6, 10}// 289	290	291	
			, {1196, -1, 5, 10}, {1196, -1, 4, 10}, {1196, -2, 8, 10}// 292	293	294	
			, {1196, -2, 7, 10}, {1196, -2, 6, 10}, {1196, -2, 5, 10}// 295	296	297	
			, {1196, -2, 4, 10}, {1196, -3, 8, 10}, {1196, -3, 7, 10}// 298	299	300	
			, {1196, -3, 6, 10}, {1196, -3, 5, 10}, {1196, -3, 4, 10}// 301	302	303	
			, {1196, -4, 8, 10}, {1196, -4, 7, 10}, {1196, -3, 6, 10}// 304	305	306	
			, {1196, -4, 5, 10}, {1196, -4, 4, 10}, {1196, -5, 8, 10}// 307	308	309	
			, {1196, -5, 7, 10}, {1196, -5, 6, 10}, {1196, -5, 5, 10}// 310	311	312	
			, {1196, -5, 4, 10}, {1196, -6, 8, 10}, {1196, -6, 7, 10}// 313	314	315	
			, {1196, -6, 6, 10}, {1196, -6, 5, 10}, {1196, -6, 4, 10}// 316	317	318	
			, {145, -3, 8, 10}, {145, -4, 8, 10}, {145, -6, 8, 10}// 319	320	321	
			, {146, -7, 8, 10}, {146, -7, 7, 10}, {146, -7, 5, 10}// 322	323	324	
			, {146, -7, 4, 10}, {1872, -2, 7, 5}, {1872, -2, 6, 5}// 325	326	327	
			, {1872, -2, 5, 5}, {1872, -3, 5, 5}, {1872, -3, 6, 5}// 328	329	330	
			, {1872, -3, 7, 5}, {1872, -4, 7, 5}, {1872, -4, 7, 5}// 331	332	333	
			, {1872, -4, 5, 5}, {1872, -2, 4, 5}, {1872, -3, 4, 5}// 334	335	336	
			, {1872, -4, 4, 5}, {1872, -5, 7, 5}, {1872, -5, 6, 5}// 337	338	339	
			, {1872, -5, 5, 5}, {1872, -5, 4, 5}, {1872, -1, 4, 5}// 340	341	342	
			, {1872, -1, 5, 5}, {1872, -1, 6, 5}, {1872, -1, 7, 5}// 343	344	345	
			, {1872, -1, 8, 5}, {1872, -2, 8, 5}, {1872, -3, 8, 5}// 346	347	348	
			, {1872, -4, 8, 5}, {1872, -5, 8, 5}, {1872, -6, 8, 5}// 349	350	351	
			, {1872, -6, 7, 5}, {1872, -6, 6, 5}, {1872, -6, 5, 5}// 352	353	354	
			, {1872, -6, 4, 5}, {1196, -1, 1, 10}, {164, 1, 3, 10}// 355	356	357	
			, {154, 1, 3, 10}, {164, 4, 3, 10}, {154, 4, 3, 10}// 358	359	360	
			, {1196, 4, 3, 10}, {1196, 4, 2, 10}, {1196, 4, 1, 10}// 361	362	363	
			, {1196, 4, 0, 10}, {1196, 3, 3, 10}, {1196, 3, 2, 10}// 364	365	366	
			, {1196, 3, 1, 10}, {1196, 3, 0, 10}, {1196, 2, 3, 10}// 367	368	369	
			, {1196, 2, 2, 10}, {1196, 2, 1, 10}, {1196, 2, 0, 10}// 370	371	372	
			, {1196, 1, 3, 10}, {1196, 1, 2, 10}, {1196, 1, 1, 10}// 373	374	375	
			, {1196, 1, 0, 10}, {1196, 0, 3, 10}, {1196, 0, 2, 10}// 376	377	378	
			, {1196, 0, 1, 10}, {1196, 0, 0, 10}, {1196, -1, 3, 10}// 379	380	381	
			, {1196, -1, 2, 10}, {1196, -1, 2, 10}, {1196, -1, 0, 10}// 382	383	384	
			, {1196, -2, 3, 10}, {1196, -2, 2, 10}, {1196, -2, 1, 10}// 385	386	387	
			, {1196, -2, 0, 10}, {1196, -3, 3, 10}, {1196, -3, 2, 10}// 388	389	390	
			, {1196, -3, 1, 10}, {1196, -3, 0, 10}, {1196, -4, 3, 10}// 391	392	393	
			, {1196, -4, 2, 10}, {1196, -4, 1, 10}, {1196, -4, 0, 10}// 394	395	396	
			, {1196, -5, 3, 10}, {1196, -5, 2, 10}, {1196, -5, 1, 10}// 397	398	399	
			, {1196, -5, 0, 10}, {1198, 4, 3, 10}, {1198, 3, 3, 10}// 400	401	402	
			, {1198, 2, 3, 10}, {1198, 1, 3, 10}, {1198, 0, 3, 10}// 403	404	405	
			, {1198, -1, 3, 10}, {1198, -2, 3, 10}, {1198, -3, 3, 10}// 406	407	408	
			, {1198, -4, 3, 10}, {1198, -5, 3, 10}, {1198, -6, 3, 10}// 409	410	411	
			, {145, -6, 3, 10}, {1202, -6, 3, 10}, {1197, -6, 3, 10}// 412	413	414	
			, {1197, -6, 2, 10}, {1197, -6, 1, 10}, {1197, -6, 0, 10}// 415	416	417	
			, {150, -7, 3, 10}, {146, -7, 3, 10}, {146, -7, 2, 10}// 418	419	420	
			, {146, -7, 1, 10}, {146, -7, 0, 10}, {145, 3, 3, 10}// 421	422	423	
			, {145, 2, 3, 10}, {145, -1, 3, 10}, {145, -3, 3, 10}// 424	425	426	
			, {145, -5, 3, 10}, {1872, -4, 3, 5}, {1872, -4, 3, 5}// 427	428	429	
			, {1872, -4, 2, 5}, {1872, -4, 1, 5}, {1872, -4, 0, 5}// 430	431	432	
			, {1872, -5, 3, 5}, {1872, -5, 3, 5}, {1872, -5, 2, 5}// 433	434	435	
			, {1872, -5, 1, 5}, {1872, -5, 0, 5}, {1872, -6, 3, 5}// 436	437	438	
			, {1872, -6, 3, 5}, {1872, -6, 2, 5}, {1872, -6, 1, 5}// 439	440	441	
			, {1872, -6, 0, 5}, {1872, 4, 3, 5}, {1872, 4, 3, 5}// 442	443	444	
			, {1872, 4, 2, 5}, {1872, 4, 1, 5}, {1872, 4, 0, 5}// 445	446	447	
			, {1872, 3, 3, 5}, {1872, 3, 3, 5}, {1872, 3, 2, 5}// 448	449	450	
			, {1872, 3, 1, 5}, {1872, 3, 0, 5}, {1872, 2, 3, 5}// 451	452	453	
			, {1872, 2, 3, 5}, {1872, 2, 2, 5}, {1872, 2, 1, 5}// 454	455	456	
			, {1872, 2, 0, 5}, {1872, 1, 3, 5}, {1872, 1, 3, 5}// 457	458	459	
			, {1872, 1, 2, 5}, {1872, 1, 1, 5}, {1872, 1, 0, 5}// 460	461	462	
			, {1872, 0, 3, 5}, {1872, 0, 3, 5}, {1872, 0, 2, 5}// 463	464	465	
			, {1872, 0, 1, 5}, {1872, 0, 0, 5}, {1872, -1, 3, 5}// 466	467	468	
			, {1872, -1, 3, 5}, {1872, -1, 2, 5}, {1872, -1, 1, 5}// 469	470	471	
			, {1872, -1, 0, 5}, {1872, -2, 3, 5}, {1872, -2, 3, 5}// 472	473	474	
			, {1872, -2, 2, 5}, {1872, -2, 1, 5}, {1872, -2, 0, 5}// 475	476	477	
			, {1872, -3, 3, 5}, {1872, -3, 3, 5}, {1872, -3, 2, 5}// 478	479	480	
			, {1872, -3, 1, 5}, {1872, -3, 0, 5}, {1195, -8, 1, 0}// 481	482	483	
			, {1195, -8, 0, 0}, {1195, 3, -1, 37}, {1195, 4, -1, 38}// 484	485	486	
			, {1195, 3, -1, 39}, {10546, 3, -1, 59}, {10547, 4, -1, 59}// 487	488	489	
			, {24, 4, -2, 57}, {24, 3, -2, 57}, {21, 2, -1, 57}// 490	491	492	
			, {21, 4, -1, 57}, {9, 2, -2, 40}, {9, 4, -2, 40}// 493	494	495	
			, {17, 2, -1, 37}, {18, 3, -2, 37}, {18, 4, -2, 37}// 496	497	498	
			, {17, 4, -1, 37}, {9962, 3, -1, 37}, {9962, 2, -1, 37}// 499	500	501	
			, {9962, 1, -1, 37}, {9962, 0, -1, 37}, {9962, -1, -1, 37}// 502	503	504	
			, {9962, -2, -1, 37}, {9962, -3, -1, 37}, {10540, 4, -2, 37}// 505	506	507	
			, {10540, 3, -2, 37}, {10540, 2, -2, 37}, {10540, 1, -2, 37}// 508	509	510	
			, {10540, 0, -2, 37}, {10540, -1, -2, 37}, {10540, -2, -2, 37}// 511	512	513	
			, {10540, -3, -2, 37}, {10538, -4, -1, 34}, {10547, 4, -2, 34}// 514	515	516	
			, {10546, -4, -2, 34}, {10540, 4, -3, 31}, {10540, 3, -3, 31}// 517	518	519	
			, {10540, 2, -3, 31}, {10540, 1, -3, 31}, {10540, 0, -3, 31}// 520	521	522	
			, {10540, -1, -3, 31}, {10540, -2, -3, 31}, {10540, -3, -3, 31}// 523	524	525	
			, {10540, -4, -3, 31}, {10538, -5, -1, 31}, {10538, -5, -2, 31}// 526	527	528	
			, {10546, -5, -3, 31}, {10540, 4, -4, 28}, {10540, 3, -4, 28}// 529	530	531	
			, {10540, 2, -4, 28}, {10540, 1, -4, 28}, {10540, 0, -4, 28}// 532	533	534	
			, {10540, -1, -4, 28}, {10540, -2, -4, 28}, {10540, -3, -4, 28}// 535	536	537	
			, {10540, -4, -4, 28}, {10540, -5, -4, 28}, {10546, -6, -4, 28}// 538	539	540	
			, {10538, -6, -1, 28}, {10538, -6, -2, 28}, {10538, -6, -3, 28}// 541	542	543	
			, {10540, 4, -5, 6}, {10540, 4, -5, 25}, {10540, 3, -5, 6}// 544	545	546	
			, {10540, 3, -5, 25}, {10540, 2, -5, 6}, {10540, 2, -5, 25}// 547	548	549	
			, {10540, 1, -5, 6}, {10540, 1, -5, 25}, {10540, 0, -5, 6}// 550	551	552	
			, {10540, 0, -5, 25}, {10540, -1, -5, 6}, {10540, -1, -5, 25}// 553	554	555	
			, {10540, -2, -5, 6}, {10540, -2, -5, 25}, {10540, -3, -5, 6}// 556	557	558	
			, {10540, -3, -5, 25}, {10540, -4, -5, 6}, {10540, -4, -5, 25}// 559	560	561	
			, {10540, -5, -5, 6}, {10540, -5, -5, 25}, {10540, -6, -5, 6}// 562	563	564	
			, {10540, -6, -5, 25}, {10540, -7, -5, 6}, {10546, -7, -5, 25}// 565	566	567	
			, {10538, -7, -1, 25}, {10538, -7, -2, 25}, {10538, -7, -3, 25}// 568	569	570	
			, {10538, -7, -4, 25}, {1195, 4, -1, 10}, {10540, 4, -5, 5}// 571	572	573	
			, {10540, 3, -5, 5}, {10540, 2, -5, 5}, {10540, 1, -5, 5}// 574	575	576	
			, {10540, 0, -5, 5}, {10540, -1, -5, 5}, {10540, -2, -5, 5}// 577	578	579	
			, {10540, -3, -5, 5}, {10540, -4, -5, 5}, {10540, -5, -5, 5}// 580	581	582	
			, {10540, -6, -5, 5}, {10540, -7, -5, 5}, {146, -7, -4, 10}// 583	584	585	
			, {148, -6, -5, 10}, {1200, 1, -4, 10}, {1197, -6, -1, 10}// 586	587	588	
			, {1197, -6, -2, 10}, {146, -7, -1, 10}, {146, -7, -2, 10}// 589	590	591	
			, {1195, 4, -2, 10}, {1195, 3, -1, 10}, {1195, 3, -2, 10}// 592	593	594	
			, {1195, 2, -1, 10}, {1195, 2, -2, 10}, {1195, 1, -1, 10}// 595	596	597	
			, {1195, 1, -2, 10}, {1195, 0, -1, 10}, {1195, 0, -2, 10}// 598	599	600	
			, {1195, -1, -1, 10}, {1195, -1, -2, 10}, {1195, -2, -1, 10}// 601	602	603	
			, {1195, -2, -2, 10}, {1195, -3, -1, 10}, {1195, -3, -2, 10}// 604	605	606	
			, {1195, -4, -1, 10}, {1195, -4, -2, 10}, {1195, -5, -1, 10}// 607	608	609	
			, {1195, -5, -2, 10}, {1872, 4, -1, 5}, {1872, 4, -2, 5}// 610	611	612	
			, {1872, 3, -1, 5}, {1872, 3, -2, 5}, {1872, 2, -1, 5}// 613	614	615	
			, {1872, 2, -2, 5}, {1872, 1, -1, 5}, {1872, 1, -2, 5}// 616	617	618	
			, {1872, 0, -1, 5}, {1872, 0, -2, 5}, {1872, -1, -1, 5}// 619	620	621	
			, {1872, -1, -2, 5}, {1872, -2, -1, 5}, {1872, -2, -2, 5}// 622	623	624	
			, {1872, -3, -1, 5}, {1872, -3, -2, 5}, {1872, -4, -1, 5}// 625	626	627	
			, {1872, -4, -2, 5}, {1872, -5, -1, 5}, {1872, -5, -2, 5}// 628	629	630	
			, {1872, -6, -1, 5}, {1872, -6, -2, 5}, {1872, 4, -4, 5}// 631	632	633	
			, {1872, 4, -4, 5}, {1872, 4, -3, 5}, {1872, 4, -4, 5}// 634	635	636	
			, {1872, 4, -4, 5}, {1872, 4, -3, 5}, {1200, 4, -4, 10}// 637	638	639	
			, {1200, 4, -4, 10}, {1196, 4, -4, 10}, {1196, 4, -3, 10}// 640	641	642	
			, {1196, 4, -4, 10}, {1196, 4, -3, 10}, {1196, -4, -4, 10}// 643	644	645	
			, {145, -3, -5, 10}, {164, 1, -5, 10}, {154, 1, -5, 10}// 646	647	648	
			, {164, 4, -5, 10}, {164, -2, -5, 10}, {154, 4, -5, 10}// 649	650	651	
			, {154, -2, -5, 10}, {1196, 4, -3, 10}, {1196, 4, -4, 10}// 652	653	654	
			, {1196, 3, -3, 10}, {1196, 3, -4, 10}, {1196, 2, -3, 10}// 655	656	657	
			, {1196, 2, -4, 10}, {1196, 1, -3, 10}, {1196, 0, -3, 10}// 658	659	660	
			, {1196, 0, -4, 10}, {1196, -1, -3, 10}, {1196, -1, -4, 10}// 661	662	663	
			, {1196, -2, -3, 10}, {1196, -2, -4, 10}, {1196, -3, -3, 10}// 664	665	666	
			, {1196, -3, -4, 10}, {1196, -4, -3, 10}, {1196, -5, -3, 10}// 667	668	669	
			, {1196, -5, -4, 10}, {145, 3, -5, 10}, {145, 2, -5, 10}// 670	671	672	
			, {145, 0, -5, 10}, {145, -1, -5, 10}, {145, -4, -5, 10}// 673	674	675	
			, {145, -5, -5, 10}, {1200, 4, -4, 10}, {1200, 3, -4, 10}// 676	677	678	
			, {1200, 2, -4, 10}, {1200, 1, -5, 10}, {1200, 0, -4, 10}// 679	680	681	
			, {1200, -1, -4, 10}, {1200, -2, -4, 10}, {1200, -3, -4, 10}// 682	683	684	
			, {1200, -4, -4, 10}, {1200, -5, -4, 10}, {1204, -6, -4, 10}// 685	686	687	
			, {1197, -6, -3, 10}, {146, -7, -3, 10}, {1872, -1, -3, 5}// 688	689	690	
			, {1872, -4, -3, 5}, {1872, -4, -4, 5}, {1872, -4, -4, 5}// 691	692	693	
			, {1872, -5, -3, 5}, {1872, -5, -4, 5}, {1872, -5, -4, 5}// 694	695	696	
			, {1872, -6, -3, 5}, {1872, -6, -4, 5}, {1872, -6, -4, 5}// 697	698	699	
			, {1872, 4, -3, 5}, {1872, 4, -4, 5}, {1872, 4, -4, 5}// 700	701	702	
			, {1872, 3, -3, 5}, {1872, 3, -4, 5}, {1872, 3, -4, 5}// 703	704	705	
			, {1872, 2, -3, 5}, {1872, 2, -4, 5}, {1872, 2, -4, 5}// 706	707	708	
			, {1872, 1, -3, 5}, {1872, 1, -4, 5}, {1872, 1, -4, 5}// 709	710	711	
			, {1872, 0, -3, 5}, {1872, 0, -4, 5}, {1872, 0, -4, 5}// 712	713	714	
			, {1872, -1, -4, 5}, {1872, -1, -4, 5}, {1872, -1, -4, 5}// 715	716	717	
			, {1872, -2, -3, 5}, {1872, -2, -4, 5}, {1872, -2, -4, 5}// 718	719	720	
			, {1872, -3, -3, 5}, {1872, -3, -4, 5}, {1872, -3, -4, 5}// 721	722	723	
			, {1195, -8, -1, 0}, {1195, -8, -2, 0}, {1195, -8, -3, 0}// 724	725	726	
			, {1195, -8, -4, 0}, {1195, -8, -5, 0}, {1195, -8, -6, 0}// 727	728	729	
			, {1195, -8, -7, 0}// 730	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new ChapellefixAddonDeed();
			}
		}

		[ Constructable ]
		public ChapellefixAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


		}

		public ChapellefixAddon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class ChapellefixAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new ChapellefixAddon();
			}
		}

		[Constructable]
		public ChapellefixAddonDeed()
		{
			Name = "Chapellefix";
		}

		public ChapellefixAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}