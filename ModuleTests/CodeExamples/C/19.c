#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <locale.h>
int main(void) {
	setlocale (LC_ALL, "Rus");
	
	int value, i, j, k, ki, value1, q1, q1i, q1i1, q2, q2i;
	int mass[10][4], mass2[10], mass3[9]={0, 0, 0, 0, 0, 0, 0, 0, 0}; //������ 1 ����� ��� ������ � �������
	srand(time(NULL));                                                //������ 2 ��������� ���������� ������� �� �����
	for(i = 0; i < 10; i++) {                                         //������ 3 ��������� ������ �������� ������� ��� ������ ������
		k = 0;
		printf("���� %d: ", i + 1);
	    value = rand()%7;
		k += value;  //������ ������� ���� �� �����
		mass[i][0] = value;
	    printf("��.%d - %d", i * 4 + 1, mass[i][0]);
		for(j = 1; j < 4; j++) {
			value = rand()%7;
			k += value;
			mass[i][j] = value;
			printf(", ��.%d - %d", i * 4 + j + 1, mass[i][j]);
		}
		printf("\n");
		mass2[i] = k;
	}
	printf("��� ����� ������ ������:\n");
	printf("1 ����� - ���� ");
	k = 0;
	ki = 0;
	for(i = 0; i < 10; i++) { //������ �������� ����
		if(mass2[i] > k) {
			k = mass2[i];
			ki = i;
		}
	}
	printf("%d", ki + 1);
	j = 0;
	for(i = 0; i < 10; i++) {
		if(mass2[i] == k && i != ki) {
			printf(", ���� %d", i + 1);
			mass3[j] = i;
			j += 1;
		}
	}
	printf(" (%d ���. ��.): ", k);
	if(mass[ki][0] != 0) { //������� �������� �������� �� ������ ����� �� ��������
		printf("��. %d (%d �.�.)", ki * 4 + 1, mass[ki][0]);
		for(j = 1; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", ��. %d (%d �.�.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}		
	else if(mass[ki][1] != 0) {
		printf("��. %d (%d �.�.)", ki * 4 + 2, mass[ki][1]);
		for(j = 2; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", ��. %d (%d �.�.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}
	else {
		printf("��. %d (%d �.�.)", ki * 4 + 4, mass[ki][3]);
	}
	for(i = 0; i < 9; i++) { //������� �������� �������� �� ������ ����� �� ��������, �� � ������ ������
		if(mass3[i] != 0) {
			printf(" + ");
			if(mass[mass3[i]][0] != 0) {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 1, mass[mass3[i]][0]);
		        for(j = 1; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", ��. %d (%d �.�.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }		
	        else if(mass[mass3[i]][1] != 0) {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 2, mass[mass3[i]][1]);
		        for(j = 2; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", ��. %d (%d �.�.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }
	        else {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 4, mass[mass3[i]][3]);
	        }
		}
		mass3[i] = 0;
	}
	printf("\n");
	printf("2 ����� - ���� ");
	ki = 0;
	value = k;
	k = 0;                             //���������� �� ���� �����, ��� � ��� ������� �����
	for(i = 0; i < 9; i++) { //������ ������ �� ��������� �������� ��������
		if(mass2[i] > k && mass2[i] < value) { //������������ ������ ������� �� ������� �����
			k = mass2[i];
			ki = i;
		}
	}
	
	printf("%d", ki + 1);
	j = 0;
	for(i = 0; i < 10; i++) {
		if(mass2[i] == k && i != ki) {
			printf(", ���� %d", i + 1);
			mass3[j] = i;
			j += 1;
		}
	}
	printf(" (%d ���. ��.): ", k);
	if(mass[ki][0] != 0) { //������� �������� �������� �� ������ ����� �� ��������
		printf("��. %d (%d �.�.)", ki * 4 + 1, mass[ki][0]);
		for(j = 1; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", ��. %d (%d �.�.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}		
	else if(mass[ki][1] != 0) {
		printf("��. %d (%d �.�.)", ki * 4 + 2, mass[ki][1]);
		for(j = 2; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", ��. %d (%d �.�.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}
	else {
		printf("��. %d (%d �.�.)", ki * 4 + 4, mass[ki][3]);
	}
	for(i = 0; i < 9; i++) { //������� �������� �������� �� ������ ����� �� ��������, �� � ������ ������
		if(mass3[i] != 0) {
			printf(" + ");
			if(mass[mass3[i]][0] != 0) {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 1, mass[mass3[i]][0]);
		        for(j = 1; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", ��. %d (%d �.�.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }		
	        else if(mass[mass3[i]][1] != 0) {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 2, mass[mass3[i]][1]);
		        for(j = 2; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", ��. %d (%d �.�.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }
	        else {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 4, mass[mass3[i]][3]);
	        }
		}
		mass3[i] = 0;
	}
	printf("\n");
	printf("3 ����� - ���� ");
	ki = 0;
	value1 = k;
	k = 0;                             //���������� �� ���� �����, ��� � ��� ������� �����
	for(i = 0; i < 9; i++) { //������ ������ �� ��������� �������� ��������
		if(mass2[i] > k && mass2[i] < value && mass2[i] < value1) { //� ����� ������� �� ������ ���� ����
			k = mass2[i];
			ki = i;
		}
	}
	
	printf("%d", ki + 1);
	j = 0;
	for(i = 0; i < 10; i++) {
		if(mass2[i] == k && i != ki) {
			printf(", ���� %d", i + 1);
			mass3[j] = i;
			j += 1;
		}
	}
	printf(" (%d ���. ��.): ", k);
	if(mass[ki][0] != 0) { //������� �������� �������� �� ������� ����� �� ��������
		printf("��. %d (%d �.�.)", ki * 4 + 1, mass[ki][0]);
		for(j = 1; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", ��. %d (%d �.�.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}		
	else if(mass[ki][1] != 0) {
		printf("��. %d (%d �.�.)", ki * 4 + 2, mass[ki][1]);
		for(j = 2; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", ��. %d (%d �.�.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}
	else {
		printf("��. %d (%d �.�.)", ki * 4 + 4, mass[ki][3]);
	}
	for(i = 0; i < 9; i++) { //������� �������� �������� �� ������� ����� �� ��������, �� � ������ ������
		if(mass3[i] != 0) {
			printf(" + ");
			if(mass[mass3[i]][0] != 0) {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 1, mass[mass3[i]][0]);
		        for(j = 1; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", ��. %d (%d �.�.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }		
	        else if(mass[mass3[i]][1] != 0) {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 2, mass[mass3[i]][1]);
		        for(j = 2; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", ��. %d (%d �.�.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }
	        else {
		        printf("��. %d (%d �.�.)", mass3[i] * 4 + 4, mass[mass3[i]][3]);
	        }
		}
		mass3[i] = 0;
	}
	printf("\n");
	printf("�������������� �������:\n"); //������� ��������� �������������� �������
	printf("��� ����� ������ ������:\n");
	printf("1 ����� - ���� ");
	q1 = 0; //������� ���������� �������� ������� �����
	q1i = 0;
	q2 = 0; //������� ���������� �������� ������� �����
	q2i = 0;
	for(i = 9; i >= 0; i--) {
		if(value == mass2[i]) {
			q1 += 1;
			q1i = i;
		}
		else if(value1 == mass2[i]) {
			q2 += 1;
			q2i = i;
		}
	}
	if(q1 >= 3) { //���� ����� ������ � �������� �� ������ ����� ���� �� 3
		printf("%d (%d ���. ��., �����): ", q1i + 1, mass2[q1i]); //������ �����
		if(mass[q1i][0] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", ��. %d (%d �.�.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		for(i = 9; i > q1i; i--) {
			if(value == mass2[i]) {
				q1i1 = i;
			}
		}
		q1i = q1i1;
		printf("2 ����� - ���� "); //������ �����
		printf("%d (%d ���. ��., ������): ", q1i + 1, mass2[q1i]);
		if(mass[q1i][0] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", ��. %d (%d �.�.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		for(i = 9; i > q1i; i--) {
			if(value == mass2[i]) {
				q1i1 = i;
			}
		}
		q1i = q1i1;
		printf("3 ����� - ���� "); //������ �����
		printf("%d (%d ���. ��., ��� ������): ", q1i + 1, mass2[q1i]);
		if(mass[q1i][0] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", ��. %d (%d �.�.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
	}
	else if(q1 == 2) { //���� ������ ����� ��������� 2 �����
		printf("%d (%d ���. ��., �����): ", q1i + 1, mass2[q1i]); //������ �����
		if(mass[q1i][0] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", ��. %d (%d �.�.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		for(i = 9; i > q1i; i--) {
			if(value == mass2[i]) {
				q1i1 = i;
			}
		}
		q1i = q1i1;
		printf("2 ����� - ���� "); //������ �����
		printf("%d (%d ���. ��., ������): ", q1i + 1, mass2[q1i]);
		if(mass[q1i][0] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", ��. %d (%d �.�.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		printf("3 ����� - ���� "); //������ �����
		printf("%d (%d ���. ��.): ", q2i + 1, mass2[q2i]);
		if(mass[q2i][0] != 0) {
			printf("��. %d (%d �.�.)", q2i * 4 + 1, mass[q2i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q2i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
	        	}
			}
		}
		else if(mass[q2i][1] != 0) {
			printf("��. %d (%d �.�.)", q2i * 4 + 2, mass[q2i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q2i][i] != 0) {
			    	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
		        }
	        }
		}
		else if(mass[q2i][2] != 0) {
			printf("��. %d (%d �.�.)", q2i * 4 + 3, mass[q2i][2]);
			if(mass[q2i][3] != 0) {
				printf(", ��. %d (%d �.�.)", q2i * 4 + 4, mass[q2i][3]);
			}
		}
		printf("\n");
	}
	else {
		printf("%d (%d ���. ��.): ", q1i + 1, mass2[q1i]); //������ �����
		if(mass[q1i][0] != 0) {
		    printf("��. %d (%d �.�.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		        if(mass[q1i][i] != 0) {
			        printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
		    printf("��. %d (%d �.�.)", q1i * 4 + 2, mass[q1i][1]);
	        for(i = 2; i < 4; i++) {
		        if(mass[q1i][i] != 0) {
			        printf(", ��. %d (%d �.�.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
	    else if(mass[q1i][2] != 0) {
			printf("��. %d (%d �.�.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
			    printf(", ��. %d (%d �.�.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		printf("2 ����� - ���� ");
		if(q2 > 1) {	//���� ������ ����� ��������� ��� ������� 2 �����
		printf("%d (%d ���. ��., �����): ", q2i + 1, mass2[q2i]); //������ �����
		    if(mass[q2i][0] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 1, mass[q2i][0]);
	    	    for(i = 1; i < 4; i++) {
		        	if(mass[q2i][i] != 0) {
			        	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
	            	}
			    }
		    }
		    else if(mass[q2i][1] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 2, mass[q2i][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			        	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
		            }
	            }
		    }
	    	else if(mass[q2i][2] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 3, mass[q2i][2]);
			    if(mass[q2i][3] != 0) {
				    printf(", ��. %d (%d �.�.)", q2i * 4 + 4, mass[q2i][3]);
			    }
		    }
	    	printf("\n");
		    for(i = 9; i > q2i; i--) {
			    if(value1 == mass2[i]) {
				q1i1 = i;
			    }
		    }
		    q2i = q1i1;
		    printf("3 ����� - ���� "); //������ �����
		    printf("%d (%d ���. ��., ������): ", q2i + 1, mass2[q2i]);
		    if(mass[q2i][0] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 1, mass[q2i][0]);
	    	    for(i = 1; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			        	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
	        	    }
			    }
		    }
		    else if(mass[q2i][1] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 2, mass[q2i][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			        	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
		            }
	            }
		    }
	    	else if(mass[q2i][2] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 3, mass[q2i][2]);
			    if(mass[q2i][3] != 0) {
			    	printf(", ��. %d (%d �.�.)", q2i * 4 + 4, mass[q2i][3]);
		    	}
		    }
		    printf("\n");
		}
		else { //���� ������ ����� - 1 �������, ������ - ���� 1 ������� � 3 - 1 �������
		    printf("%d (%d ���. ��.): ", q2i + 1, mass2[q2i]); //������ �����
		    if(mass[q2i][0] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 1, mass[q2i][0]);
	    	    for(i = 1; i < 4; i++) {
		            if(mass[q2i][i] != 0) {
			            printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
	                }
			    }
		    }
		    else if(mass[q2i][1] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 2, mass[q2i][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			            	printf(", ��. %d (%d �.�.)", q2i * 4 + i + 1, mass[q2i][i]);
		            }
	            }
		    }
	        else if(mass[q2i][2] != 0) {
			    printf("��. %d (%d �.�.)", q2i * 4 + 3, mass[q2i][2]);
			    if(mass[q2i][3] != 0) {
				    printf(", ��. %d (%d �.�.)", q2i * 4 + 4, mass[q2i][3]);
			    }
		    }
	        printf("\n");
			printf("3 ����� - ���� ");
			printf("%d (%d ���. ��.): ", ki + 1, mass2[ki]); //������ �����
		    if(mass[ki][0] != 0) {
			    printf("��. %d (%d �.�.)", ki * 4 + 1, mass[ki][0]);
	    	    for(i = 1; i < 4; i++) {
		            if(mass[ki][i] != 0) {
			                printf(", ��. %d (%d �.�.)", ki * 4 + i + 1, mass[ki][i]);
	                }
			    }
		    }
		    else if(mass[ki][1] != 0) {
			    printf("��. %d (%d �.�.)", ki * 4 + 2, mass[ki][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[ki][i] != 0) {
			            printf(", ��. %d (%d �.�.)", ki * 4 + i + 1, mass[ki][i]);
		            }
	            }
		    }
	        else if(mass[ki][2] != 0) {
			    printf("��. %d (%d �.�.)", ki * 4 + 3, mass[ki][2]);
			    if(mass[ki][3] != 0) {
				    printf(", ��. %d (%d �.�.)", ki * 4 + 4, mass[ki][3]);
			    }
		    }
		}
	}
	
	return 0;
}