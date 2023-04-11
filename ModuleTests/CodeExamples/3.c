#include <stdio.h>
#include <stdlib.h>
#include <iso646.h>
#include <time.h>
#include <windows.h>
#include <math.h>

int clear (void){    
  while ( getchar() != '\n' );
}

int main(void){
	SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
	
	int floors[10][4];
	int sum[10] = {0};
    int sumIndex[10];
	int menuChoose, a;
    int control, control2, control3, ctrlCount, seeMode;
    int top[3] = {0};
    int topIndex[3] = {0};

	srand(time(NULL));
    seeMode = 0;
	menuChoose = 1;

    while (menuChoose != 0){
        printf("'Шумные этажи'\n");
        printf("Главное меню\n1. Вычисления\n2. Доп. задание\n3. Режим отладки\n0. Выход\n");
        
        while (scanf("%d", &menuChoose) != 1){
            printf("\n>> Введённое значение не является цифрой\n\n");
            clear();
            printf("Главное меню\n1. Вычисления\n2. Доп. задание\n3. Режим отладки\n0. Выход\n");
        }
        
        switch (menuChoose)
        {   
            case 1:
            {
				control = 0;
                control2 = 0;
                control3 = 0;
                ctrlCount = 0;

                for(int i = 0; i < 10; i++){
                    sum[i] = 0;	
				}

				for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
						floors[i][j] = rand()%7;
					}
				}

                printf("\n");
				for(int i = 9; i >= 0; i--){
					printf("Этаж %d: ", i+1);
					for(int j = 0; j < 4; j++){
						if(j!=3){
							printf("кв.%d - %d, ", (i+1)*4-3+j, floors[i][j]);
						}else if(j==3){
							printf("кв.%d - %d", (i+1)*4-3+j, floors[i][j]);
						}
					}
					printf("\n");
				}
				printf("\n");
				
                for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
                        sum[i] += floors[i][j];
					}
				}

                for(int i = 0; i < 10; i++){
					sumIndex[i] = i+1;
				}

                if (seeMode == 1){
                    printf("\n");
                    printf(">> До изменений\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                    printf("\n");
                }
                
                for (int i = 0; i < 10 - 1; i++){
                    for (int j = (10 - 1); j > i; j--){
                        if (sum[j - 1] > sum[j]) {
                            int temp = sum[j - 1];
                            sum[j - 1] = sum[j];
                            sum[j] = temp;
                            
                            int temp2 = sumIndex[j - 1];
                            sumIndex[j - 1] = sumIndex[j];
                            sumIndex[j] = temp2;
                        }
                    }
                }
                printf("Список самых шумных этажей:\n");

                printf("1 место - Этаж %d (%d шум. ед.)", sumIndex[9], sum[9]);

                for(int i = 8; i >= 0; i--){
                    if (sum[i] == sum[9]){
                        printf(" и Этаж %d", sumIndex[i], sum[i]);
                        control++;
                    } else{
                        break;
                    }
                }
   
                printf(": ");
                for(int i = 0; i < control+1; i++){
                    
                    for(int j = 0; j < 4; j++){
                        if (floors[sumIndex[9-i]-1][j] != 0){
                            ctrlCount++;
                        }
                    }
                    
                    for(int j = 0; j < 4; j++){
                        if ((floors[sumIndex[9-i]-1][j] != 0) and ctrlCount > 1){
                            printf("кв.%d (%d ш.е), ", (sumIndex[9-i])*4-3+j, floors[sumIndex[9-i]-1][j]);
                            ctrlCount--;
                        } else if ((floors[sumIndex[9-i]-1][j] != 0) and ctrlCount == 1){
                            printf("кв.%d (%d ш.е)", (sumIndex[9-i])*4-3+j, floors[sumIndex[9-i]-1][j]);
                        }
                    }

                    ctrlCount = 0;

                    if (i+1 < control+1){
                        printf(" и ");
                    }
                }

                printf("\n");
                ctrlCount = 0;
                printf("2 место - Этаж %d (%d шум. ед.)", sumIndex[9-1-control], sum[9-1-control]);
                for(int i = 7-control; i >= 0; i--){
                    if (sum[i] == sum[9-1-control]){
                        printf(" и Этаж %d", sumIndex[i], sum[i]);
                        control2++;
                    } else {
                        break;
                    }
                }
                printf(": ");
                for(int i = 0; i < control2+1; i++){
                    for(int j = 0; j < 4; j++){
                        if (floors[sumIndex[9-1-control-i]-1][j] != 0){
                            ctrlCount++;
                        }
                    }
                    for(int j = 0; j < 4; j++){
                        if ((floors[sumIndex[9-1-control-i]-1][j] != 0) and ctrlCount > 1){
                            ctrlCount--;
                            printf("кв.%d (%d ш.е), ", (sumIndex[9-1-control-i])*4-3+j, floors[sumIndex[9-1-control-i]-1][j]);
                        } else if ((floors[sumIndex[9-1-control-i]-1][j] != 0) and ctrlCount == 1){
                            printf("кв.%d (%d ш.е)", (sumIndex[9-1-control-i])*4-3+j, floors[sumIndex[9-1-control-i]-1][j]);
                        }
                    }
                    ctrlCount = 0;
                    if (i+1 < control2+1){
                        printf(" и ");
                    }
                }

                printf("\n");
                ctrlCount = 0;
                printf("3 место - Этаж %d (%d шум. ед.)", sumIndex[9-2-control-control2], sum[9-2-control-control2]);
                for(int i = 6-control-control2; i >= 0; i--){
                    if (sum[i] == sum[9-2-control-control2]){
                        printf(" и Этаж %d", sumIndex[i], sum[i]);
                        control3++;
                    } else {
                        break;
                    }
                }
                printf(": ");
                for(int i = 0; i < control3+1; i++){
                    for(int j = 0; j < 4; j++){
                        if (floors[sumIndex[9-2-control-control2-i]-1][j] != 0){
                            ctrlCount++;
                        }
                    }
                    for(int j = 0; j < 4; j++){
                        if ((floors[sumIndex[9-2-control-control2-i]-1][j] != 0) and ctrlCount > 1){
                            ctrlCount--;
                            printf("кв.%d (%d ш.е), ", (sumIndex[9-2-control-control2-i])*4-3+j, floors[sumIndex[9-2-control-control2-i]-1][j]);
                        } else if ((floors[sumIndex[9-2-control-control2-i]-1][j] != 0) and ctrlCount == 1){
                            printf("кв.%d (%d ш.е)", (sumIndex[9-2-control-control2-i])*4-3+j, floors[sumIndex[9-2-control-control2-i]-1][j]);
                        }
                    }
                    ctrlCount = 0;
                    if (i+1 < control3+1){
                        printf(" и ");
                    }
                }
                printf("\n");

                if (seeMode == 1){
                    printf("\n");
                    printf(">> После сортировки пузырьком\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                }
                
				printf("\n>> Чтобы вернутся в главное меню введите любой символ\n");
                scanf("%d", &a);
                clear();
                break;
			}
            case 2:
            {
                control = 0;
                control2 = 0;
                control3 = 0;
                ctrlCount = 0;

                for(int i = 0; i < 10; i++){
                    sum[i] = 0;	
				}

				for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
						floors[i][j] = rand()%7;
					}
				}

                printf("\n");
				for(int i = 9; i >= 0; i--){
					printf("Этаж %d: ", i+1);
					for(int j = 0; j < 4; j++){
						if(j!=3){
							printf("кв.%d - %d, ", (i+1)*4-3+j, floors[i][j]);
						}else if(j==3){
							printf("кв.%d - %d", (i+1)*4-3+j, floors[i][j]);
						}
					}
					printf("\n");
				}
				printf("\n");
				
                for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
                        sum[i] += floors[i][j];
					}
				}

                for(int i = 0; i < 10; i++){
					sumIndex[i] = i+1;
				}

                if (seeMode == 1){
                    printf("\n");
                    printf(">> До изменений\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                    
                }
                

                for (int i = 0; i < 10 - 1; i++){
                    for (int j = (10 - 1); j > i; j--){
                        if (sum[j - 1] > sum[j]) {
                            int temp = sum[j - 1];
                            sum[j - 1] = sum[j];
                            sum[j] = temp;
                            
                            int temp2 = sumIndex[j - 1];
                            sumIndex[j - 1] = sumIndex[j];
                            sumIndex[j] = temp2;
                        }
                    }
                }

                if (seeMode == 1){
                    printf("\n");
                    printf(">> После сортировки пузырьком\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
				    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                    printf("\n");
                }
                
                for (int i = 0; i < 10; i++){
                    for (int j = 9; j > i; j--){
                        if ((sum[j - 1] == sum[j]) and (sumIndex[j] > sumIndex[j - 1])) {
                            int temp2 = sumIndex[j];
                            sumIndex[j] = sumIndex[j - 1];
                            sumIndex[j - 1] = temp2;
                        }
                    }
                }

                for(int i = 0; i < 3; i++){
                    top[i] = sum[9-i];
                    topIndex[i] = sumIndex[9-i];
                }

                printf("Список самых шумных этажей:\n");
            
                if (top[0]==top[1]){
                    printf("1 место - Этаж %d (%d шум. ед., ближе)", topIndex[0], top[0]);
                } else {
                    printf("1 место - Этаж %d (%d шум. ед.)", topIndex[0], top[0]);
                }
                
                printf(": ");
                for(int j = 0; j < 4; j++){
                    if (floors[topIndex[0]-1][j] != 0){
                        ctrlCount++;
                    }
                }
                
                for(int j = 0; j < 4; j++){
                    if ((floors[topIndex[0]-1][j] != 0) and ctrlCount > 1){
                        printf("кв.%d (%d ш.е), ", (topIndex[0])*4-3+j, floors[topIndex[0]-1][j]);
                        ctrlCount--;
                    } else if ((floors[topIndex[0]-1][j] != 0) and ctrlCount == 1){
                        printf("кв.%d (%d ш.е)", (topIndex[0])*4-3+j, floors[topIndex[0]-1][j]);
                    }
                }
                ctrlCount = 0;
                printf("\n");

                if (top[0]==top[1]){
                    printf("2 место - Этаж %d (%d шум. ед., дальше)", topIndex[1], top[1]);
                } else if (top[1]==top[2]){
                    printf("2 место - Этаж %d (%d шум. ед., ближе)", topIndex[1], top[1]);
                } else {
                    printf("2 место - Этаж %d (%d шум. ед.)", topIndex[1], top[1]);
                }
                printf(": ");
                for(int j = 0; j < 4; j++){
                    if (floors[topIndex[1]-1][j] != 0){
                        ctrlCount++;
                    }
                }
                
                for(int j = 0; j < 4; j++){
                    if ((floors[topIndex[1]-1][j] != 0) and ctrlCount > 1){
                        printf("кв.%d (%d ш.е), ", (topIndex[1])*4-3+j, floors[topIndex[1]-1][j]);
                        ctrlCount--;
                    } else if ((floors[topIndex[1]-1][j] != 0) and ctrlCount == 1){
                        printf("кв.%d (%d ш.е)", (topIndex[1])*4-3+j, floors[topIndex[1]-1][j]);
                    }
                }
                ctrlCount = 0;
                printf("\n");

                if (top[0]==top[2]){
                    printf("3 место - Этаж %d (%d шум. ед., ещё дальше)", topIndex[2], top[2]);
                } else if (top[1]==top[2]){
                    printf("3 место - Этаж %d (%d шум. ед., дальше)", topIndex[2], top[2]);
                } else {
                    printf("3 место - Этаж %d (%d шум. ед.)", topIndex[2], top[2]);
                }
                printf(": ");
                for(int j = 0; j < 4; j++){
                    if (floors[topIndex[2]-1][j] != 0){
                        ctrlCount++;
                    }
                }
                
                for(int j = 0; j < 4; j++){
                    if ((floors[topIndex[2]-1][j] != 0) and ctrlCount > 1){
                        printf("кв.%d (%d ш.е), ", (topIndex[2])*4-3+j, floors[topIndex[2]-1][j]);
                        ctrlCount--;
                    } else if ((floors[topIndex[2]-1][j] != 0) and ctrlCount == 1){
                        printf("кв.%d (%d ш.е)", (topIndex[2])*4-3+j, floors[topIndex[2]-1][j]);
                    }
                }
                ctrlCount = 0;
                printf("\n");
                
                if (seeMode == 1){
                    printf("\n");
                    printf(">> После сортировки на близость к первому этажу\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                }
                
				printf("\n>> Чтобы вернутся в главное меню введите любой символ\n");
                scanf("%d", &a);
                clear();
                break;
            }			
            case 3:
            {   
                printf("\n");
                if (seeMode == 0){
                    seeMode = 1;
                    printf(">> Режим отладки: включён\n");
                } else {
                    seeMode = 0;
                    printf(">> Режим отладки: выключен\n");
                }
                printf("\n");
                clear();
                break;
            }
		}
	}
	return 0; 
}