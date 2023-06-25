﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables {

	public static int nLevels = 28;
    public static bool finishOrderingProcess = false;
    public static string[] Scene = new string[nLevels];
    public static string[] SceneNumbers = new string[nLevels];
    public static string[] ScenePath = new string[nLevels];
    //-2: final
    //-1: inicial
    //0: nada
    //1: normal
    //2: camino
    //3: suma
    //4: sustraccion
    //5: multiplicacion
    //6: division
    //7: CW
    //8: CCW
    //9: muerte //no es necesario usarlo

    //10X: camino con un numero especifico (X)

    //Stages
    /*
	suma
	1*
	2*
	3*
	//rotacion
	4*
	5*
	//sustraccion
	6*
	7*
	8*
	9
	10
	//multiplicacion
	11
	12
	13*
	14*
	15*
	//division
	16
	17*
	18*
	19*
	20*
	*/

    //1?
    public static void SetScenes()
    {
        //sumas

        //filas|columnas|posxini|posyini|imgtut
		Scene[0] = "5|5|3|1|1|Scene5$   9|   9|   9|   9|   9|  9|   1|   1|  -1|   9|  9|   1|   1|   1|   9|  9|  -2|   1|   1|   9|  9|   9|   9|   9|   9|";
        //dadoUp/dadoLeft/dadoForward
        SceneNumbers[0] = "1|1|1$    0|   0|   0|   0|   0|  0|   4|   2|   0|   0|  0|   6|   3|   3|   0|  0|   0|   5|   6|   0|  0|   0|   0|   0|   0|";
        //punto 0,0 está arriba a la izquierda y se mueve en positivo en ambos ejes
        ScenePath[0] = "1,2|2,2|3,2";

		Scene[1] = "5|3|1|1|0|Scene3$ 0 | 9 | 0 | 1 | -1 | 9 | 1 | 1 | 9 | -2 | 1 | 9 | 0 | 9 | 0 |";
        SceneNumbers[1] = "2|1|1$ 0 | 0 | 0 | 2 | 0 | 0 | 4 | 3 | 0 | 0 | 5 | 0 | 0 | 0 | 0 |";
        ScenePath[1] = "2,1|3,1";

		Scene[2] = "5 | 5 | 3 | 1 | 0|Scene1$ 0 | 1 | 9 | 9 | 0 | 1 | 1 | 1 | -1 | 9 | 9 | 1 | 1 | 1 | 0 | 9 | 1 | 9 | 1 | 1 | 1 | -2 | 1 | 1 | 0 |";
        SceneNumbers[2] = "1|2|3$ 0 | 7 | 0 | 0 | 0 | 6 | 5 | 3 | 0 | 0 | 0 | 7 | 6 | 5 | 0 | 0 | 10 | 0 | 6 | 5 | 9 | 0 | 5 | 3 | 0 |";
        ScenePath[2] = "1,2|2,2|2,1|3,1";

		Scene[3] = "5|5|3|3|0|Scene2$ 1 | -2 | 1 | 0 | 0 | 1 | 1 | 1 | 1 | 0 | 1 | 1 | 1 | 1 | 1 | 9 | 8 | 1 | -1 | 1 | 0 | 9 | 1 | 1 | 1 |";
        SceneNumbers[3] = "1|1|1$ 4 | 0 | 5 | 4 | 0 | 9 | 8 | 5 | 3 | 0 | 4 | 5 | 4 | 3 | 3 | 0 | 3 | 2 | 0 | 3 | 0 | 7 | 4 | 3 | 5 |";
        ScenePath[3] = "3,2|3,1|2,1|1,1";

		Scene[4] = "4 | 6 | 4 | 1 | 0|Scene4$ 1 | -2 | 1 | 9 | 1 | 1 | 1 | 1 | 7 | 1 | -1 | 1 | 1 | 8 | 1 | 8 | 1 | 1 | 0 | 1 | 1 | 1 | 1 | 0 |";
        SceneNumbers[4] = "3|5|1$ 94 | 0 | 14 | 2 | 4 | 4 | 73 | 67 | 16 | 13 | 0 | 3 | 64 | 38 | 29 | 9 | 4 | 3 | 0 | 33 | 48 | 3 | 8 | 0 |";
        ScenePath[4] = "2,4|2,3|1,3|1,2|2,2|2,1|1,1";

        //restas
		Scene[5] = "5|4|2|1|0|Scene6$ 0 | 9 | 9 | 0 | 1 | 4 | -1 | 9 | 1 | 1 | 1 | 1 | -2 | 1 | 1 | 1 | 0 | 1 | 1 | 0 |";
        SceneNumbers[5] = "1|3|2$ 0 | 0 | 0 | 0 | -4 | 4 | 5 | 1 | 4 | 2 | 2 | 0 | 0 | -2 | 0 | -3 | -4 | 1 | 5 | 4 |";
        ScenePath[5] = "1,1|2,1|3,1";
        
		Scene[6] = "6 | 6 | 4 | 1 | 0|Scene7$ 0 | 1 | 1 | 1 | 9 | 0 | 1 | 1 | 4 | 1 | -1 | 9 | 1 | 1 | 1 | 1 | 9 | 0 | 1 | 4 | 3 | 1 | 0 | 0 | 1 | 1 | 1 | 1 | 1 | 1 | 0 | -2 | 1 | 1 | 1 | 1 | ";
        SceneNumbers[6] = "6|4|3$ 0 | 14 | 12 | 7 | 0 | 0 | 12 | 10 | 16 | 10 | 0 | 0 | 21 | 16 | 13 | 13 | 0 | 0 | -4 | 7 | -3 | 11 | 0 | 0 | -5 | -6 | -4 | 22 | 31 | 13 | 0 | 0 | -3 | -10 | -22 | 31 |";
        ScenePath[6] = "1,8|1,7|1,6|1,5|2,5|3,5|4,5|4,4|4,3|4,2";
        
		Scene[7] = "6 | 11 | 9 | 1 | 0|Scene8$ 0 | 0 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 9 | 0 | 0 | 1 | 3 | 7 | 3 | 1 | 1 | 4 | 1 | -1 | 9 | 0 | -2 | 1 | 1 | 1 | 1 | 3 | 1 | 1 | 1 | 1 | 0 | 1 | 1 | 1 | 4 | 1 | 1 | 1 | 1 | 0 | 0 | 1 | 1 | 0 | 1 | 8 | 1 | 3 | 1 | 9 | 0 | 1 | 1 | 1 | 0 | 0 | 1 | 1 | 1 | 1 | 0 | 1 | 1 |";
        SceneNumbers[7] = "1|1|1$ 0 | 0 | 22 | 12 | -11 | -23 | -3 | 2 | 5 | 0 | 0 | 0 | 25 | 21 | 14 | -29 | -11 | 2 | 3 | 2 | 0 | 0 | 0 | 0 | 13 | -7 | -8 | -23 | -1 | 2 | 4 | 3 | 1 | 0 | -35 | -24 | 19 | -21 | -4 | 3 | -1 | -1 | 0 | 0 | 23 | 13 | 0 | 12 | -13 | -8 | -5 | -3 | 0 | 0 | 1 | -4 | -12 | 0 | 0 | -4 | -7 | 6 | -4 | 0 | 2 | 3 |";
        ScenePath[7] = "1,8|1,7|2,7|3,7|4,7|4,6|4,5|4,4|3,4|2,4|2,3|1,3|1,2|2,2";

		Scene[8] = "6|11|9|1|0|Scene9$ 0 | 0 | 0 | 0 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 0 | 0 | 9 | 0 | 1 | 1 | 1 | 4 | 1 | -1 | 1 | 1 | -2 | 1 | 1 | 1 | 1 | 1 | 1 | 9 | 1 | 1 | 1 | 8 | 1 | 1 | 8 | 1 | 1 | 4 | 1 | 1 | 1 | 1 | 1 | 1 | 8 | 3 | 1 | 1 | 8 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 | 1 |";
        SceneNumbers[8] = "3|5|1$ 0 | 0 | 0 | 0 | 1 | 3 | 4 | 10 | 3 | 6 | 2 | 4 | 0 | -2 | -2 | 7 | 11 | -3 | 11 | 8 | 0 | 4 | -21 | -110 | -75 | -32 | -4 | -12 | -11 | 14 | 0 | 4 | 10 | 21 | -72 | -47 | -24 | -12 | -26 | 7 | 19 | 12 | 7 | 14 | 39 | -53 | -28 | -35 | -19 | -16 | 3 | 4 | 15 | 21 | 20 | -6 | -32 | -22 | 11 | -26 | -9 | -5 | 8 | 22 | -4 | 16 |";
        ScenePath[8] = "2,9|3,9|3,8|3,7|3,6|4,6|4,5|4,4|4,3|4,2|3,2|2,2";
        ///////los de arriba son fijos para escenas tutorial
		Scene[23] = "6|7|5|1|0|Scene23$	1|   1|   1|   1|   1|   1|   1|   1|   2|   2|   2|   2|  -1|   1|   1|   2|   1|   1|   1|   1|   1|   1|   2|   1|   0|   0|   0|   0|  1|  -2|   1|   0|   0|   0|   0|  1|   1|   1|   0|   0|   0|   0|";
        SceneNumbers[23] = "1|1|1$   -4|  -7|   5|   1|   4|   4|   2|  -3|   8|   5|   3|   2|   0|   3|    2|   9|   9|   7|   4|   5|   4|    3|  17|   3|   0|   0|   0|   0|   30|   0|  32|   0|   0|   0|   0|   14|   6|  17|   0|   0|   0|   0";
        ScenePath[23] = "1,4|1,3|1,2|1,1|2,1|3,1";

		Scene[21] = "10|9|7|1|0|Scene21$  0|   0|   0|   0|   0|   1|   1|   1|   1|   0|   0|   1|   1|   1|   1|   1|  -1|   1|   0|   0|   1|   1|   1|   1|   1|   1|   1|   0|   0|   1|   1|   1|   1|   1|   1|   0|   1|   1|   1|   1|   1|   1|   1|   0|   0|   1|   1|   1|   1|   1|   1|   0|   0|   0|   1|   1|   1|   1|   1|   0|   0|   0|   0|    1|   1|   1|   1|   1|   0|   0|   0|   0|   1|   1|   1|   1|   1|   0|   0|   0|   0|   1|  -2|   1|   1|   1|   0|   0|   0|   0|";
        SceneNumbers[21] = "3|4|3$    0|   0|   0|   0|   0|  20|  12|   3|   4|  0|   0|  43|  37|  28|  12|   9|   0|   5|  0|   0|  43|  33|  26|  16|  10|   6|   8|  0|   0|  54|  38|  29|  27|  19|  14|   0| 	 213| 124|  99|  71|  55|  47|  42|   0|   0|  98| 262| 123| 100|  98|  74|   0|   0|   0|  182| 347| 226| 171| 101|   0|   0|   0|   0|  284| 368| 326| 243| 187|   0|   0|   0|   0|  583| 723| 552| 344| 258|   0|   0|   0|   0|  642|  -2| 736| 541| 345|   0|   0|   0|   0|";
        ScenePath[21] = "2,7|2,6|2,5|2,4|3,4|4,4|4,3|5,3|6,3|6,2|7,2|8,2|8,1|9,1";

		Scene[22] = "9|9|4|4|0|Scene22$     1|   1|   1|   1|   1|   1|   1|   1|   1|    1|   1|   1|   1|   1|   8|   1|   1|   1|   1|   1|   8|   1|   1|   1|   1|   1|   1|   1|   1|   1|   1|   1|   1|   1|   1|   1|    1|   1|   1|   1|  -1|   1|  -2|   1|   1|   1|   1|   1|   1|   1|   1|   0|   0|   0|   1|   1|   1|   1|   8|   1|   0|   0|   0|  1|   1|   1|   1|   1|   1|   0|   0|   0|   1|   1|   1|   1|   1|   1|   0|   0|   0|";
        SceneNumbers[22] = "1|1|1$   53|  42|  78|  60| 109| 132| 230| 319| 334|   39|  40|  65|  74| 117| 191| 243| 311| 451|   36|  41|  43|  69| 190| 308| 377| 223| 235|  32|  32|  26|   6|   4| 341| 568| 521| 431|  34|  26|  17|   1|   0|   3|  34| 523| 443|   12|  16|   9|  12|   2|   3|   0|   0|   0|  33|  12|   8|   5|   3|   4|   0|   0|   0|  23|  21|  10|  12|   7|   8|   0|   0|   0|   13|  14|  15|  15|   9|   3|   0|   0|   0|";
        ScenePath[22] = "5,4|6,4|6,3|6,2|5,2|4,2|3,2|2,2|2,3|1,3|1,4|1,5|2,5|2,6|3,6|4,6";

		Scene[24] = "8|11|2|2|0|Scene24$  9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|  9|   1|  -1|   1|   1|   8|   1|   1|   1|   1|   9|  9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|   9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|  9|   1|   7|   1|   1|   7|   1|   1|  -2|   1|   9|   9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|";
        SceneNumbers[24] = "1|1|1$    0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|  0|   4|   3|   7|  52|  91| 130| 340| 376| 400|   0|    0|   1|   0|   4|  71|  89| 144| 233| 377| 450|   0|  0|   4|   2|   3|  65|  55| 145| 212| 378| 750|   0|    0|   3|   3|   5|  21|  34|  36| 300| 755| 999|   0|   0|   6|   5|   8|  13|  21|  32|  65|   0| 980|   0|   0|   9|  14|  10|  12|  22|  25|  15|  80| 641|   0|    0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[24] = "3,2|4,2|5,2|5,3|5,4|5,5|4,5|3,5|2,5|2,6|2,7|2,8|3,8|4,8";

		Scene[25] = "7|7|5|1|0|Scene25$   0|   9|   9|   9|   9|   9|   0|  9|   1|   1|   1|   4|  -1|   9| 9|   1|   7|   1|   1|   4|   9|  9|   1|   3|   0|   3|   1|   9|  9|   1|   1|   1|   1|   1|   9| 9|   1|   1|   4|   1|  -2|   9|  0|   9|   9|   9|   9|   9|   0|";
        SceneNumbers[25] = "10|3|7$   0|   0|   0|   0|   0|   0|   0|   0|  35|  14|   3|  13|   0|   0|   0|  16| -17|  -4|  14|  16|   0|  0|  15| -13|   0|   5|  24|   0|  0|  12| -30|   8|  19|  32|   0|    0|  20| -43| -40|   3| 256|   0|  0|   0|   0|   0|   0|   0|   0|";
        ScenePath[25] = "1,4|1,3|2,3|2,2|3,2|4,2|5,2|5,3|5,4";

		Scene[26] = "6|6|4|0|0|Scene26$  0|   0|   0|   9|  -1|   1|   0|   9|   9|   9|   1|   7|    0|   9|   8|   1|   1|   3|  7|   1|   1|   9|   4|   1|  -2|   1|   8|   1|   1|   1|   1|   1|   1|   9|   9|   1|";
        SceneNumbers[26] = "1|1|1$   0|   0|   0|   0|   5|   4|    0|   0|   0|   0|   2|   3|  0|   0|  -3|   1|   3|  -2| -5|  -7|  -2|   0|   5|   3|  5|   4|  -1|   1|   2|   3|  0|   3|   5|   0|   0|   4|";
        ScenePath[26] = "1,4|2,4|3,4|4,4|4,3|4,2|3,2|3,1|3,0";

		Scene[27] = "8|9|5|1|0|Scene27$  0|   0|   0|   0|   1|   1|   1|   0|   0|   0|   0|   0|   0|   1|  -1|   1|   0|   0|   0|   0|   0|   0|   1|   1|   1|   1|   1|   1|   1|   1|   0|   1|   7|   4|   1|   1|   1|   1|   1|   0|   1|   1|   1|   1|   1|  -2|   1|   1|   9|   9|   1|   1|   8|   1|  1|   1|   8|   1|   1|   3|   1|   9|   0|  1|   1|   1|   9|   9|   9|   9|   0|   0|";
        SceneNumbers[27] = "1|1|1$   0|   0|   0|   0|   5|   4|   2|   0|   0|   0|   0|   0|   0|   2|   0|   1|   0|   0|    0|   0|   0|   0|   4|   2|   5|   2|  -2|   33|  34|  45|   0|   4|   3|   5|   2|   4|   23| -56| -50|   0|   5|   3|   0|   1|   3|   0| -37| -36|   0|   0|  -1|  -2|  -1|  12|   23| -21| -22| -14|  -8|  -6|  -9|   0|   0| 34|  28|  36|   0|   0|   0|   0|   0|   0|";
        ScenePath[27] = "2,5|3,5|3,6|3,7|4,7|5,7|5,6|5,5|6,5|6,4|6,3|6,2|5,2|5,1";

		Scene[9] = "7|7|5|1|0|Scene28$  1|   1|   1|   1|   1|   1|   1|   1|   7|   4|   1|   1|  -1|   1|   1|   1|   8|   1|   1|   1|   1|   1|   1|   3|   1|   1|   8|   1|   1|   1|   1|   1|   1|   3|   1|   1|   7|   4|   7|   1|   1|   1|   1|   1|   1|   1|   1|  -2|   1|";
        SceneNumbers[9] = "1|1|1$   2|  10|   3|   5|   5|   4|   4|    3|   9|  11|   8|   2|   0|   4|   -8|  -2|   7|   4|   3|   4|   4|  165|  73|  -2|  29| -35| -21|   6| 	  27|  16|   5| -14| -19|  14|  22|  209|  14|  30|  16| -40| -75|  25|  29|  29|  35|  31|  25|   0|  25|";
        ScenePath[9] = "1,4|2,4|2,3|2,2|1,2|1,1|2,1|3,2|4,2|4,1|5,1|5,2|5,3|4,3|4,4|3,4|3,5|4,5|5,4|5,5";

		Scene[10] = "7|7|5|1|3|Scene10$   0|   0|   0|   0|   0|   1|   0|    0|   0|   0|   0|   1|  -1|   1|   0|   0|   0|   0|   1|   1|   1|   0|   0|   0|   0|   1|   1|   1|   0|   1|   1|   1|   1|   4|   1|   1|  -2|   1|   1|   1|   5|   1|  0|   1|   1|   1|   1|   1|   1|";
        SceneNumbers[10] = "3|1|2$    0|   0|   0|   0|   0|   4|   0|  0|   0|   0|   0|   5|   0|   6|    0|   0|   0|   0|  -3|   5|  20|    0|   0|   0|   0|  13|   8|  21|   0|-250| 100|   3|  11|  13|  15|   35|   0| 125|  25|   5|   5|  30|  0| 259| 525|  23|  18|   8|   1";   //6
        ScenePath[10] = "1,5|2,5|3,5|4,5|5,5|5,4|5,3|5,2";

		Scene[11] = "8|9|6|2|0|Scene11$  0|   0|   0|   0|   0|   0|   0|   0|   0|  0|   1|   5|   1|   1|   1|   1|   1|   0|    0|  -2|   1|   8|   1|   4|  -1|   1|   0|    0|   1|   1|   1|   1|   1|   5|   1|   0|    0|   1|   1|   4|   8|   1|   1|   1|   0|    0|   1|   1|   1|   1|   3|   1|   1|   0|   0|   1|   1|   1|   4|   8|   1|   1|   0|    0|   1|   1|   1|   1|   1|  -2|   1|   0|";
        SceneNumbers[11] = "4|3|1$   0|   0|   0|   0|   0|   0|   0|   0|   0|  0|   5|  -3|   1|  -1|   3|  -4|   1|   0|    0|   0|-140|  -8|  -2|   7|   0|  35|   0|    0| -90| -55|  25|   1|   9|   5|   7|   0|   -4|   3|  -4|  85|  80|  60|  20|  15|   0|    0|  30|  18|  12|  85| 300|  25|  -3|   0|  6|  14|   9|  20| 100|  80|   1|   2|   0|   6|  14|   9|  15| -30|   5|   0|   4|   0|";
        ScenePath[11] = "3,6|4,6|4,5|5,5|4,4|4,3|3,3|3,2|2,2";

		Scene[12] = "8|9|7|4|0|Scene12$  0|   9|   1|   1|   1|   9|   9|   0|   0|  0|   9|   1|   1|   1|   9|   9|   0|   0|   9|   1|   5|   1|  -2|   1|   9|   9|   0|   9|   1|   1|   8|   0|   1|   1|   1|   9|    9|   1|   1|   3|   8|   1|   1|  -1|   9|    9|   9|   9|   1|   1|   4|   1|   1|   9|    0|   0|   9|   1|   1|   1|   9|   9|   0|   0|   0|   9|   9|   9|   9|   9|   9|   0|";
        SceneNumbers[12] = "5|3|1$   0|   0|  -7|  13| -11|   0|   0|   0|   0|   0|   0|   4|  -5|   8|   0|   0|   0|   0|    0| -11| -19|   2|   0| 363|   0|   0|   0|   0|  30|  -8| -18|   0| -33|  -5|  15|   0|  0|  67| -11|  -6|  -5|   3|   8|   0|   0|    0|   0|   0|  -4|  20|  14|   9|   7|   0|   0|   0|   0|  15|   7|  -6|   0|   0|   0|  	0|   0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[12] = "4,6|5,6|5,5|4,5|4,4|4,3|4,2|3,2|2,2|3,3|3,5|2,5";

		Scene[13] = "11|11|4|1|0|Scene13$    9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|  9|   9|   4|   1|  -1|   1|  -2|   1|   1|   9|   9|    9|   7|   1|   4|   1|   1|   1|   1|   1|   1|   9|  9|   1|   7|   1|   0|   0|   0|   1|   7|   7|   9|   9|   1|   3|   0|   0|   0|   0|   0|   1|   1|   9|   9|   3|   1|   0|   0|   0|   0|   0|   3|   3|   9|     9|   1|   1|   0|   0|   0|   0|   0|   1|   1|   9|   9|   1|   4|   1|   0|   0|   0|   7|   1|   1|   9|  9|   4|   1|   7|   1|   5|   1|   4|   7|   1|   9|  9|   9|   7|   1|   5|   1|   1|   1|   4|   9|   9|  9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|";
        SceneNumbers[13] = "1|8|5$   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   7|   9|   0|-700|   0|   5|  -1|   0|   0|   0|  -1|  13|  14|   7|-700|   3|   4|   6|   2|   0|   0| -14|  25|  15|   0|   0|   0|   8|   4|  13|   0|   0| -13| -12|   0|   0|   0|   0|   0|  15|  -2|   0|  0|   1|  10|   0|   0|   0|   0|   0|  80|  54|   0|   0| -15|  -3|   0|   0|   0|   0|   0| 154|  72|   0|    0|  -4|   7|   9|   0|   0|   0| 424| 160|  98|   0|   0|   3|  10|  12| -13|  69| 800| 832| 256| 145|   0|   0|   0|   3|  -7| -10|  70|-700| 756| 640|   0|   0|    0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[13] = "1,3|2,3|2,2|2,1|3,1|4,1|5,1|5,2|6,2|7,2|8,2|9,2|9,3|9,4|9,5|9,6|1,5";

		Scene[14] = "9|8|6|5|0|Scene14$  0|   9|   9|   9|   9|   9|   0|   0|    9|   5|   7|   4|   8|   1|   9|   0|   9|   8|   4|   3|   5|   1|  -2|   9|   9|   4|   5|   4|   3|   9|   9|   0|   9|   3|   4|   3|   4|   9|   9|   0|   9|   4|   8|   5|   3|   5|  -1|   9|  9|   5|   4|   8|   1|   1|   9|   9|   0|   9|   9|   9|   9|   9|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";
        SceneNumbers[14] = "2|2|1$   0|   0|   0|   0|   0|   0|   0|   0|   0| 256| 360|-508|2056|4112|   2|   0|   0| 300| 512|  -8| 112|-896|   0|   0|     0| 192| 320|-264|-240|   0|   0|   0|    0|  12|  89|-256|-126|   0|   0|   0|   0|  86| 120|  -8|   6|   4|   0|   0|   0|  98| 128|  32|   8|   4|   0|   0|    0|   0|   0|   0|   0|   0|   0|   0|    0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[14] = "5,5|6,5|6,4|6,3|6,2|5,2|5,3|4,3|3,3|2,3|2,4|2,5";

		Scene[15] = "9|9|7|1|4|Scene15$  0|   9|   9|   9|   9|   9|   9|   9|   0| 9|   1|   1|   6|   1|   1|   5|  -1|   9|   9|   1|   5|   1|   1|   9|   9|   9|   0|   9|   1|   7|   3|   1|   9|   0|   0|   0|   9|   9|   1|   1|   6|   9|   0|   0|   0|    0|   0|   9|   1|   1|   9|   9|   0|   0|   0|   0|   0|   9|  -2|   9|   0|   0|   0|  0|   0|   0|   0|   9|   9|   0|   0|   0|  0|   0|   0|   0|   0|   0|   0|   0|   0|";
        SceneNumbers[15] = "1|4|5$   0|   0|   0|   0|   0|   0|   0|   0|   0|   0| 500| 250| 125|  25|   5|   5|   0|   0|   0| 275|   1|  25|  75|   0|   0|   0|   0|    0| 100| 125| 125| 250|   0|   0|   0|   0|   0|   0|  25|  25| 275|   0|   0|   0|   0|   0|   0|   0| 125|   1|   0|   0|   0|   0|   0|   0|   0|  16|   0|   0|   0|   0|   0|   0|   0|   0|   8|  25|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[15] = "1,6|1,5|1,4|1,3|2,3|2,2|3,2|3,3|3,4|4,4|5,4|6,4";

		Scene[16] = "9|9|6|2|0|Scene16$  0|   0|   0|   0|   0|   0|   9|   0|   0|   0|   9|   9|   9|   9|   9|   1|   9|   0|   9|  -2|   1|   3|   1|   6|  -1|   9|   0|   0|   9|   1|   1|   5|   5|   1|   9|   0|    0|   9|   3|   5|   8|   1|   1|   9|   0|   0|   9|   1|   1|   1|   6|   4|   9|   0|   0|   9|   7|   1|   8|   1|   1|   5|   9|   0|   9|   1|   9|   9|   9|   9|   9|   0| 	0|   0|   9|   0|   0|   0|   0|   0|   0|";
        SceneNumbers[16] = "25|5|6$  0|   0|   0|   0|   0|   0|   0|   0|   0|    0|   0|   0|   0|   0|   0| 130|   0|   0|    0|   0|  50|  25|  25|  30|   0|   0|   0|    0|   0|  16|   8| 750|   5|  25|   0|   0|    0|   0|   4|   1|   6| 150|  64|   0|   0|    0|   0|  27|   8|   1| 750|  32|   0|   0|   0|   0|  44|  32|   8|   4| 256| 512|   0|   0|   0|  13|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[16] = "2,5|3,5|4,5|5,5|4,4|4,3|2,4|2,3|2,2";

		Scene[17] = "7|7|5|1|0|Scene17$   0|   9|   9|   9|   9|   9|   0|  9|   1|   1|   1|   5|  -1|   9|   9|   1|   4|   1|   1|   5|   9|   9|   6|   1|   6|   1|   1|   9|  9|   1|   5|   1|   3|   1|   9|   9|  -2|   1|   3|   1|   1|   9|    0|   9|   9|   9|   9|   9|   0|";
        SceneNumbers[17] = "4|4|2$    0|   0|   0|   0|   0|   0|   0|  0| 256|  32| 128|   8|   0|   0|     0|  68|   4|  64|  16|   8|   0|     0|   4|  30| 512|   2|  64|   0|   0|  12|   8| 448|   6|  32|   0|    0|   0|  -4| -64|   4| 256|   0|    0|   0|   0|   0|   0|   0|   0|";
        ScenePath[17] = "1,4|2,4|2,3|3,3|2,2|4,3|5,3|2,1|3,1|5,2";

		Scene[18] = "9|8|6|5|0|Scene18$   9|   1|   1|   1|   1|   3|   9|   0|    8|   1|   1|   8|   1|   1|   1|   9|   6|   1|   1|   4|   1|   1|  -2|   9|    1|   1|   1|   6|   1|   9|   9|   0|    1|   3|   1|   1|   1|   9|   9|   0|  1|   1|   8|   1|   1|   5|  -1|   9|   8|   8|   1|   1|   1|   5|   1|   9|  9|   1|   1|   6|   1|   5|   9|   0|   0|   9|   9|   9|   9|   9|   0|   0|";
        SceneNumbers[18] = "1|1|1$    0|  90| 128| 600|-172|  16|   0|   0|   32| 256| 360|-508|-520|   8|   2|   0|   256| 300| 512|   4| 124|  -4|   0|   0|  200| 192| 320| 512|   2|   0|   0|   0|     16| 128| 250| 310|   8|   0|   0|   0|   160|  64|  16|   4|   2|   2|   0|   0|   128|  32|   8|   4|   4|   3|   1|   0|     4|  16|  30|   4|   6|   5|   3|   0|    0|   0|   0|   0|   0|   0|   0|   0|";
        ScenePath[18] = "5,5|5,4|5,3|6,3|6,2|6,1|6,0|5,1|4,1|3,1|3,2|3,3|2,3|1,3|2,4|2,5";

		Scene[19] = "8|9|4|1|0|Scene19$  1|   1|   1|   1|   1|   1|   1|   1|   0|    1|   7|   1|   6|  -1|   6|   8|   1|   0|   1|   1|   1|   4|   6|   1|   1|   1|   0|   1|   1|   1|   1|   5|   1|   1|   1|   0|   1|   1|   1|   1|   7|   3|   1|   1|   0|  1|   1|   5|   7|   1|   1|   8|   1|   0|  1|  -2|   1|   8|   3|   4|   1|   1|   0|    1|   1|   1|   8|   1|   1|   1|   1|   0|";
        SceneNumbers[19] = "30|20|10$   30|   45|   25|  60|  40|   4|   2|   3|   0|  -25|  -30|   20|  50|   0| -50|   1|   4|   0|  -30|  -50|  -70|   5| -20|  60|   5|  -1|   5|   40|  -20|  -30| -10|   1|   4|   5|   8|   9|   35|  340|   20|   1| -20|   2|  34|   9|  16|   9|-2400|   56|  43|  19|   3| -47|  17|  34|   1|    0|-1120|  13|  30| -17|  41| -21|  -5|  2|    3|  259|  60| -10| -36|  45|   5|   9|";
        ScenePath[19] = "1,3|2,3|1,2|1,1|2,1|3,1|3,2|4,2|3,3|2,4|3,4|4,4|1,5|1,6|4,5|5,5|5,6|6,5|6,4|6,3|5,3|5,2|6,2";

		Scene[20] = "7|7|5|1|0|Scene20$   0|   9|   9|   9|   9|   9|   0|   9|   1|   1|   1|   5|  -1|   9|   9|   1|   1|   1|   1|   5|   9|     9|   3|   1|   6|   1|   1|   9|  9|   1|   1|   1|   1|   1|   9|   9|  -2|   1|   3|   1|   1|   9|   0|   9|   9|   9|   9|   9|   0|";
        SceneNumbers[20] = "4|4|2$    0|   0|   0|   0|   0|   0|   0|    0| 256|  32| 128|   8|   0|   0|   0|  16|   8|  64|  16|   8|   0|   0|   4|  32| 512|   2|  64|   0| 0|  12|   8|   8|   6|  32|   0|   0|   0|  32|   8|   4| 256|   0|  0|   0|   0|   0|   0|   0|   0|";
        ScenePath[20] = "1,4|2,4|2,3|3,3|4,3|3,4|3,2|2,2|3,1|4,1";
    }
	//Tutoriales
	public static string Scene91 = "4|5|3|1|1$    9|   9|   9|   9|   9|  9|   9|   1|  -1|   9|   9|  -2|   1|   9|   9|  9|   9|   9|   9|   9|";
	public static string Scene91Numbers = "1|1|1$    0|   0|   0|   0|   0|    0|   0|   2|   2|   0|  0|   0|   3|   3|   0|    0|   0|   0|   0|   0|";
	public static string Scene91Path = "1,3|1,2|2,1|3,1";
	
	public static string Scene92 = "4|5|3|1|1$   9|   9|   9|   9|   9|    9|   9|   4|  -1|   9|   9|  -2|   1|   9|   9|   9|   9|   9|   9|   9|";
	public static string Scene92Numbers = "1|1|1$   0|   0|   0|   0|   0|   0|   0|   2|   2|   0|    0|   0|   1|   3|   0|  0|   0|   0|   0|   0|";
    public static string Scene92Path = "1,3|1,2|2,1|3,1";

	public static string Scene93 = "4|5|3|1|1$   9|   9|   9|   9|   9|   9|   9|   5|  -1|   9|    9|  -2|   1|   9|   9|   9|   9|   9|   9|   9|";
	public static string Scene93Numbers = "2|2|2$   0|   0|   0|   0|   0|   0|   0|   4|   2|   0|  0|   0|   8|   3|   0|   0|   0|   0|   0|   0|";
    public static string Scene93Path = "1,3|1,2|2,1|3,1";

	public static string Scene94 = "4|5|3|1|1$   9|   9|   9|   9|   9|   9|   9|   6|  -1|   9|  9|  -2|   1|   9|   9|   9|   9|   9|   9|   9|";
	public static string Scene94Numbers = "5|5|5$   0|   0|   0|   0|   0|  0|   0|  10|   2|   0|   0|   0|   2|   3|   0|  0|   0|   0|   0|   0|";
    public static string Scene94Path = "1,3|1,2|2,1|3,1";

    public static string getSceneName(string name)
    {
        for(int i = 0; i < Scene.Length; i++)
        {
            if(Scene[i].Split(new char[1] { '$' })[0].Split(new char[1] { '|' })[5] == name)
            {
                return name;
            }
        }
        return name;
    }

    //entrega el indice donde se encuentra el string de escena 'name'
    public static int getSceneIndex(string name)
    {
        for (int i = 0; i < Scene.Length; i++)
        {
            if (Scene[i].Split(new char[1] { '$' })[0].Split(new char[1] { '|' })[5] == name)
            {
                return i;
            }
        }
        return 0;
    }

    //entrega el nombre de la Scene que se encuentra en el indice 'num'
    public static string getIndexScene(string num)
    {
        return Scene[int.Parse(num) - 1].Split(new char[1] { '$' })[0].Split(new char[1] { '|' })[5];
    }

    public static void orderScenes()
    {
        float[] sceneDifficulty = new float[nLevels];
        for(int i = 0; i < nLevels; i++)
        {
            int boardSize = 0;
            int operationsSum = 1;
            int operationsSub = 0;
            int operationsMul = 0;
            int operationsDiv = 0;
            string[] boardCells = Scene[i].Split(new char[1] { '$' })[1].Split(new char[1] { '|' });
            for(int j = 0; j < boardCells.Length - 1; j++)
            {
                if(int.Parse(boardCells[j]) != 9 && int.Parse(boardCells[j]) != 0)
                {
                    boardSize++;
                    if (int.Parse(boardCells[j]) == 3) operationsSum++;
                    if (int.Parse(boardCells[j]) == 4) operationsSub++;
                    if (int.Parse(boardCells[j]) == 5) operationsMul++;
                    if (int.Parse(boardCells[j]) == 6) operationsDiv++;
                }
            }
            int totalOperations = operationsSum + operationsSub + operationsMul + operationsDiv;
            int pathSize = ScenePath[i].Split(new char[1] { '|' }).Length;

            sceneDifficulty[i] += operationsSum * 100f + operationsSub * 150f + operationsMul * 300f + operationsDiv * 500f;
            sceneDifficulty[i] += totalOperations * 500f;

            sceneDifficulty[i] += pathSize * 50f;
            
            sceneDifficulty[i] += boardSize * 10f;
        }

        bool ordering = true;
        int iteration = 0;
        while (ordering)
        {
            ordering = false;
            //cambiar el numero inicial para dejar etapas fijas
            for(int i = 9; i < sceneDifficulty.Length - 1 - iteration; i++)
            {
                if(sceneDifficulty[i] > sceneDifficulty[i + 1])
                {
                    float aux = sceneDifficulty[i + 1];
                    sceneDifficulty[i + 1] = sceneDifficulty[i];
                    sceneDifficulty[i] = aux;

                    string auxScene = Scene[i + 1];
                    Scene[i + 1] = Scene[i];
                    Scene[i] = auxScene;
                    string auxNumbers = SceneNumbers[i + 1];
                    SceneNumbers[i + 1] = SceneNumbers[i];
                    SceneNumbers[i] = auxNumbers;
                    string auxPath = ScenePath[i + 1];
                    ScenePath[i + 1] = ScenePath[i];
                    ScenePath[i] = auxPath;

                    ordering = true;
                }
            }
            iteration++;
        }
        finishOrderingProcess = true;
    }
}