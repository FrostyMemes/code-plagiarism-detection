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
	int floors[10][4]; //��㬥�� ���ᨢ ��� ������
	int sum[10] = {0}; //���ᨢ �㬭��� �⠦��
    int sumIndex[10]; //���ᨢ �����ᮢ �⠦�� (�㦥� ��� ���४⭮� �����䨪�樨 �㬭�� �⠦�� ��᫥ ���஢��)
	int menuChoose, a; //��६���� ��� ࠡ��� �������� ����
    int control, control2, control3, ctrlCount, seeMode; //��६���� ��� ����⭮�� �⮡ࠦ���� १����
    int top[3] = {0}; //���ᨢ ᠬ�� �㬭�� �⠦�� (��� ���. �������)
    int topIndex[3] = {0}; //������� ᠬ�� �㬭�� �⠦�� (��� ���. �������)

	srand(time(NULL));
    seeMode = 0;
	menuChoose = 1;

    while (menuChoose != 0){
        printf("'�㬭� �⠦�'\n");
        printf("������� ����\n1. ���᫥���\n2. ���. �������\n3. ����� �⫠���\n4. � �ணࠬ��\n0. ��室\n");
        
        while (scanf("%d", &menuChoose) != 1){
            printf("\n>> ����񭭮� ���祭�� �� ���� ��ன\n\n");
            clear();
            printf("������� ����\n1. ���᫥���\n2. ���. �������\n3. ����� �⫠���\n4. � �ணࠬ��\n0. ��室\n");
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

                //���������� ��㬥୮�� ���ᨢ� ��� ������ �ᥢ���砩�묨 �᫠��
				for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
						floors[i][j] = rand()%7;
					}
				}

                //�뢮� ��㬥୮�� ���ᨢ� ��� ������ �� �࠭
                printf("\n");
				for(int i = 9; i >= 0; i--){
					printf("�⠦ %d: ", i+1);
					for(int j = 0; j < 4; j++){
						if(j!=3){
							printf("��.%d - %d, ", (i+1)*4-3+j, floors[i][j]);
						}else if(j==3){
							printf("��.%d - %d", (i+1)*4-3+j, floors[i][j]);
						}
					}
					printf("\n");
				}
				printf("\n");
				
                //���᫥��� �㬭��� ������� �⠦�
                for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
                        sum[i] += floors[i][j];
					}
				}

                //���������� �����ᮢ �⠦��
                for(int i = 0; i < 10; i++){
					sumIndex[i] = i+1;
				}

                //�⫠���. �⮡ࠦ���� �㬭��� ������� �⠦� �� ���஢��
                if (seeMode == 1){
                    printf("\n");
                    printf(">> �� ���������\n");
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
                
                //����஢�� �㬭��� �⠦��
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
                printf("���᮪ ᠬ�� �㬭�� �⠦��:\n");

            //1 ���� = = = = =
                //�뢮� ᠬ��� �㬭��� �⠦�
                printf("1 ���� - �⠦ %d (%d ��. ��.)", sumIndex[9], sum[9]);

                //�஢�ઠ � �뢮� �⠦�� � ⠪�� �� �㬭�����
                for(int i = 8; i >= 0; i--){
                    if (sum[i] == sum[9]){
                        printf(" � �⠦ %d", sumIndex[i], sum[i]);
                        control++;
                    } else{
                        break;
                    }
                }

                //�뢮� �㬭��� ������ ������ �� �뢥������ ࠭�� �⠦��    
                printf(": ");
                for(int i = 0; i < control+1; i++){
                    
                    //�஢�ઠ �� ���-�� �� �㫥��� ���祭�� ������ (�� �㦭� ��� �᪫�祭�� ����⮩ � ����)
                    for(int j = 0; j < 4; j++){
                        if (floors[sumIndex[9-i]-1][j] != 0){
                            ctrlCount++;
                        }
                    }
                    
                    for(int j = 0; j < 4; j++){
                        if ((floors[sumIndex[9-i]-1][j] != 0) and ctrlCount > 1){
                            printf("��.%d (%d �.�), ", (sumIndex[9-i])*4-3+j, floors[sumIndex[9-i]-1][j]);
                            ctrlCount--;
                        } else if ((floors[sumIndex[9-i]-1][j] != 0) and ctrlCount == 1){
                            printf("��.%d (%d �.�)", (sumIndex[9-i])*4-3+j, floors[sumIndex[9-i]-1][j]);
                        }
                    }

                    ctrlCount = 0;

                    //�஢�ઠ �� �������⥫�� �⠦�
                    if (i+1 < control+1){
                        printf(" � ");
                    }
                }

            //2 ���� = = = = =
                printf("\n");
                ctrlCount = 0;
                printf("2 ���� - �⠦ %d (%d ��. ��.)", sumIndex[9-1-control], sum[9-1-control]);
                for(int i = 7-control; i >= 0; i--){
                    if (sum[i] == sum[9-1-control]){
                        printf(" � �⠦ %d", sumIndex[i], sum[i]);
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
                            printf("��.%d (%d �.�), ", (sumIndex[9-1-control-i])*4-3+j, floors[sumIndex[9-1-control-i]-1][j]);
                        } else if ((floors[sumIndex[9-1-control-i]-1][j] != 0) and ctrlCount == 1){
                            printf("��.%d (%d �.�)", (sumIndex[9-1-control-i])*4-3+j, floors[sumIndex[9-1-control-i]-1][j]);
                        }
                    }
                    ctrlCount = 0;
                    if (i+1 < control2+1){
                        printf(" � ");
                    }
                }

            //3 ���� = = = = =
                printf("\n");
                ctrlCount = 0;
                printf("3 ���� - �⠦ %d (%d ��. ��.)", sumIndex[9-2-control-control2], sum[9-2-control-control2]);
                for(int i = 6-control-control2; i >= 0; i--){
                    if (sum[i] == sum[9-2-control-control2]){
                        printf(" � �⠦ %d", sumIndex[i], sum[i]);
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
                            printf("��.%d (%d �.�), ", (sumIndex[9-2-control-control2-i])*4-3+j, floors[sumIndex[9-2-control-control2-i]-1][j]);
                        } else if ((floors[sumIndex[9-2-control-control2-i]-1][j] != 0) and ctrlCount == 1){
                            printf("��.%d (%d �.�)", (sumIndex[9-2-control-control2-i])*4-3+j, floors[sumIndex[9-2-control-control2-i]-1][j]);
                        }
                    }
                    ctrlCount = 0;
                    if (i+1 < control3+1){
                        printf(" � ");
                    }
                }
                printf("\n");

                //�⪫����. �஢�ઠ �㬭��� �⠦�� ��᫥ ���஢��
                if (seeMode == 1){
                    printf("\n");
                    printf(">> ��᫥ ���஢�� ����쪮�\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                }
                
				printf("\n>> �⮡� ������� � ������� ���� ������ �� ᨬ���\n");
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

                //���������� ��㬥୮�� ���ᨢ� ��� ������ �ᥢ���砩�묨 �᫠��
				for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
						floors[i][j] = rand()%7;
					}
				}

                //�뢮� ��㬥୮�� ���ᨢ� ��� ������ �� �࠭
                printf("\n");
				for(int i = 9; i >= 0; i--){
					printf("�⠦ %d: ", i+1);
					for(int j = 0; j < 4; j++){
						if(j!=3){
							printf("��.%d - %d, ", (i+1)*4-3+j, floors[i][j]);
						}else if(j==3){
							printf("��.%d - %d", (i+1)*4-3+j, floors[i][j]);
						}
					}
					printf("\n");
				}
				printf("\n");
				
                //���᫥��� �㬭��� ������� �⠦�
                for(int i = 0; i < 10; i++){
					for(int j = 0; j < 4; j++){
                        sum[i] += floors[i][j];
					}
				}

                //���������� �����ᮢ �⠦��
                for(int i = 0; i < 10; i++){
					sumIndex[i] = i+1;
				}

                //�⫠���. �⮡ࠦ���� �㬭��� ������� �⠦� �� ���஢��
                if (seeMode == 1){
                    printf("\n");
                    printf(">> �� ���������\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                    
                }
                

                //����஢�� �㬭��� �⠦��
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

                //�⫠���
                if (seeMode == 1){
                    printf("\n");
                    printf(">> ��᫥ ���஢�� ����쪮�\n");
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
                
                //����஢�� �� ������� � ��ࢮ�� �⠦� ��������� �㬭�� �⠦��
                for (int i = 0; i < 10; i++){
                    for (int j = 9; j > i; j--){
                        if ((sum[j - 1] == sum[j]) and (sumIndex[j] > sumIndex[j - 1])) {
                            int temp2 = sumIndex[j];
                            sumIndex[j] = sumIndex[j - 1];
                            sumIndex[j - 1] = temp2;
                        }
                    }
                }

                //�롮� ���� ᠬ�� �㬭��
                for(int i = 0; i < 3; i++){
                    top[i] = sum[9-i];
                    topIndex[i] = sumIndex[9-i];
                }

                printf("���᮪ ᠬ�� �㬭�� �⠦��:\n");
            
            //1 ���� = = = = = 
                if (top[0]==top[1]){
                    printf("1 ���� - �⠦ %d (%d ��. ��., �����)", topIndex[0], top[0]);
                } else {
                    printf("1 ���� - �⠦ %d (%d ��. ��.)", topIndex[0], top[0]);
                }
                
                printf(": ");
                for(int j = 0; j < 4; j++){
                    if (floors[topIndex[0]-1][j] != 0){
                        ctrlCount++;
                    }
                }
                
                for(int j = 0; j < 4; j++){
                    if ((floors[topIndex[0]-1][j] != 0) and ctrlCount > 1){
                        printf("��.%d (%d �.�), ", (topIndex[0])*4-3+j, floors[topIndex[0]-1][j]);
                        ctrlCount--;
                    } else if ((floors[topIndex[0]-1][j] != 0) and ctrlCount == 1){
                        printf("��.%d (%d �.�)", (topIndex[0])*4-3+j, floors[topIndex[0]-1][j]);
                    }
                }
                ctrlCount = 0;
                printf("\n");

            //2 ���� = = = = =
                if (top[0]==top[1]){
                    printf("2 ���� - �⠦ %d (%d ��. ��., �����)", topIndex[1], top[1]);
                } else if (top[1]==top[2]){
                    printf("2 ���� - �⠦ %d (%d ��. ��., �����)", topIndex[1], top[1]);
                } else {
                    printf("2 ���� - �⠦ %d (%d ��. ��.)", topIndex[1], top[1]);
                }
                printf(": ");
                for(int j = 0; j < 4; j++){
                    if (floors[topIndex[1]-1][j] != 0){
                        ctrlCount++;
                    }
                }
                
                for(int j = 0; j < 4; j++){
                    if ((floors[topIndex[1]-1][j] != 0) and ctrlCount > 1){
                        printf("��.%d (%d �.�), ", (topIndex[1])*4-3+j, floors[topIndex[1]-1][j]);
                        ctrlCount--;
                    } else if ((floors[topIndex[1]-1][j] != 0) and ctrlCount == 1){
                        printf("��.%d (%d �.�)", (topIndex[1])*4-3+j, floors[topIndex[1]-1][j]);
                    }
                }
                ctrlCount = 0;
                printf("\n");

            //3 ���� = = = = =
                if (top[0]==top[2]){
                    printf("3 ���� - �⠦ %d (%d ��. ��., ��� �����)", topIndex[2], top[2]);
                } else if (top[1]==top[2]){
                    printf("3 ���� - �⠦ %d (%d ��. ��., �����)", topIndex[2], top[2]);
                } else {
                    printf("3 ���� - �⠦ %d (%d ��. ��.)", topIndex[2], top[2]);
                }
                printf(": ");
                for(int j = 0; j < 4; j++){
                    if (floors[topIndex[2]-1][j] != 0){
                        ctrlCount++;
                    }
                }
                
                for(int j = 0; j < 4; j++){
                    if ((floors[topIndex[2]-1][j] != 0) and ctrlCount > 1){
                        printf("��.%d (%d �.�), ", (topIndex[2])*4-3+j, floors[topIndex[2]-1][j]);
                        ctrlCount--;
                    } else if ((floors[topIndex[2]-1][j] != 0) and ctrlCount == 1){
                        printf("��.%d (%d �.�)", (topIndex[2])*4-3+j, floors[topIndex[2]-1][j]);
                    }
                }
                ctrlCount = 0;
                printf("\n");
                
            //�⪫����. �஢�ઠ �㬭��� �⠦�� ��᫥ ���஢��
                if (seeMode == 1){
                    printf("\n");
                    printf(">> ��᫥ ���஢�� �� �������� � ��ࢮ�� �⠦�\n");
                    for(int i = 0; i < 10; i++){
					printf("%d ", sum[i]);
                    }
                    printf("\n");
                    for(int i = 0; i < 10; i++){
                        printf("%d ", sumIndex[i]);
                    }
                    printf("\n");
                }
                
				printf("\n>> �⮡� ������� � ������� ���� ������ �� ᨬ���\n");
                scanf("%d", &a);
                clear();
                break;
            }			
            case 3:
            {   
                printf("\n");
                if (seeMode == 0){
                    seeMode = 1;
                    printf(">> ����� �⫠���: ������\n");
                } else {
                    seeMode = 0;
                    printf(">> ����� �⫠���: �몫�祭\n");
                }
                printf("\n");
                clear();
                break;
            }
            case 4:
            {
                printf("\n�ࠪ��᪮� ������� �10 15.12.2022\n");
                printf("�ணࠬ�� ᤥ���: ��⢥�� �� ����22�-2\n");
                printf("����� �⫠���: �������� �ப���஫�஢��� ��������� ��।������ �⠦�� �� �㬭���\n");
                printf("               ��ࢠ� ��ப� - ���� �㬭���� �⠦�\n");
                printf("               ���� ��ப� - ����� �⠦�\n");
                printf("\n>> �⮡� ������� � ������� ���� ������ �� ᨬ���\n");
                scanf("%d", &a);
                clear();
                break;
            }
		}
	}
	return 0; 
}