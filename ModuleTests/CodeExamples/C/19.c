#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <locale.h>
int main(void) {
	setlocale (LC_ALL, "Rus");
	
	int value, i, j, k, ki, value1, q1, q1i, q1i1, q2, q2i;
	int mass[10][4], mass2[10], mass3[9]={0, 0, 0, 0, 0, 0, 0, 0, 0}; //массив 1 нужен для этажей и жильцов
	srand(time(NULL));                                                //массив 2 сохраняет количество жильцов по этажу
	for(i = 0; i < 10; i++) {                                         //массив 3 Сохраняет схожие значения жильцов для разных этажей
		k = 0;
		printf("Этаж %d: ", i + 1);
	    value = rand()%7;
		k += value;  //Нахожу уровень шума на этаже
		mass[i][0] = value;
	    printf("кв.%d - %d", i * 4 + 1, mass[i][0]);
		for(j = 1; j < 4; j++) {
			value = rand()%7;
			k += value;
			mass[i][j] = value;
			printf(", кв.%d - %d", i * 4 + j + 1, mass[i][j]);
		}
		printf("\n");
		mass2[i] = k;
	}
	printf("Топ самых шумных этажей:\n");
	printf("1 место - Этаж ");
	k = 0;
	ki = 0;
	for(i = 0; i < 10; i++) { //Нахожу максимум шума
		if(mass2[i] > k) {
			k = mass2[i];
			ki = i;
		}
	}
	printf("%d", ki + 1);
	j = 0;
	for(i = 0; i < 10; i++) {
		if(mass2[i] == k && i != ki) {
			printf(", Этаж %d", i + 1);
			mass3[j] = i;
			j += 1;
		}
	}
	printf(" (%d шум. ед.): ", k);
	if(mass[ki][0] != 0) { //Начинаю выводить квартиры на первом месте по шумности
		printf("кв. %d (%d ш.е.)", ki * 4 + 1, mass[ki][0]);
		for(j = 1; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", кв. %d (%d ш.е.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}		
	else if(mass[ki][1] != 0) {
		printf("кв. %d (%d ш.е.)", ki * 4 + 2, mass[ki][1]);
		for(j = 2; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", кв. %d (%d ш.е.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}
	else {
		printf("кв. %d (%d ш.е.)", ki * 4 + 4, mass[ki][3]);
	}
	for(i = 0; i < 9; i++) { //Начинаю выводить квартиры на первом месте по шумности, но с других этажей
		if(mass3[i] != 0) {
			printf(" + ");
			if(mass[mass3[i]][0] != 0) {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 1, mass[mass3[i]][0]);
		        for(j = 1; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", кв. %d (%d ш.е.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }		
	        else if(mass[mass3[i]][1] != 0) {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 2, mass[mass3[i]][1]);
		        for(j = 2; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", кв. %d (%d ш.е.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }
	        else {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 4, mass[mass3[i]][3]);
	        }
		}
		mass3[i] = 0;
	}
	printf("\n");
	printf("2 место - Этаж ");
	ki = 0;
	value = k;
	k = 0;                             //Происходит всё тоже самое, что и для первого места
	for(i = 0; i < 9; i++) { //Нахожу второе по максимуму значение шумности
		if(mass2[i] > k && mass2[i] < value) { //Единственное особое отличие от первого места
			k = mass2[i];
			ki = i;
		}
	}
	
	printf("%d", ki + 1);
	j = 0;
	for(i = 0; i < 10; i++) {
		if(mass2[i] == k && i != ki) {
			printf(", Этаж %d", i + 1);
			mass3[j] = i;
			j += 1;
		}
	}
	printf(" (%d шум. ед.): ", k);
	if(mass[ki][0] != 0) { //Начинаю выводить квартиры на втором месте по шумности
		printf("кв. %d (%d ш.е.)", ki * 4 + 1, mass[ki][0]);
		for(j = 1; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", кв. %d (%d ш.е.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}		
	else if(mass[ki][1] != 0) {
		printf("кв. %d (%d ш.е.)", ki * 4 + 2, mass[ki][1]);
		for(j = 2; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", кв. %d (%d ш.е.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}
	else {
		printf("кв. %d (%d ш.е.)", ki * 4 + 4, mass[ki][3]);
	}
	for(i = 0; i < 9; i++) { //Начинаю выводить квартиры на втором месте по шумности, но с других этажей
		if(mass3[i] != 0) {
			printf(" + ");
			if(mass[mass3[i]][0] != 0) {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 1, mass[mass3[i]][0]);
		        for(j = 1; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", кв. %d (%d ш.е.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }		
	        else if(mass[mass3[i]][1] != 0) {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 2, mass[mass3[i]][1]);
		        for(j = 2; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", кв. %d (%d ш.е.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }
	        else {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 4, mass[mass3[i]][3]);
	        }
		}
		mass3[i] = 0;
	}
	printf("\n");
	printf("3 место - Этаж ");
	ki = 0;
	value1 = k;
	k = 0;                             //Происходит всё тоже самое, что и для первого этажа
	for(i = 0; i < 9; i++) { //Нахожу третье по максимуму значение шумности
		if(mass2[i] > k && mass2[i] < value && mass2[i] < value1) { //И снова отличие от первых двух мест
			k = mass2[i];
			ki = i;
		}
	}
	
	printf("%d", ki + 1);
	j = 0;
	for(i = 0; i < 10; i++) {
		if(mass2[i] == k && i != ki) {
			printf(", Этаж %d", i + 1);
			mass3[j] = i;
			j += 1;
		}
	}
	printf(" (%d шум. ед.): ", k);
	if(mass[ki][0] != 0) { //Начинаю выводить квартиры на третьем месте по шумности
		printf("кв. %d (%d ш.е.)", ki * 4 + 1, mass[ki][0]);
		for(j = 1; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", кв. %d (%d ш.е.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}		
	else if(mass[ki][1] != 0) {
		printf("кв. %d (%d ш.е.)", ki * 4 + 2, mass[ki][1]);
		for(j = 2; j < 4; j++) {
			if(mass[ki][j] != 0) {
				printf(", кв. %d (%d ш.е.)", ki * 4 + j + 1, mass[ki][j]);
			}
		}
	}
	else {
		printf("кв. %d (%d ш.е.)", ki * 4 + 4, mass[ki][3]);
	}
	for(i = 0; i < 9; i++) { //Начинаю выводить квартиры на третьем месте по шумности, но с других этажей
		if(mass3[i] != 0) {
			printf(" + ");
			if(mass[mass3[i]][0] != 0) {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 1, mass[mass3[i]][0]);
		        for(j = 1; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", кв. %d (%d ш.е.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }		
	        else if(mass[mass3[i]][1] != 0) {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 2, mass[mass3[i]][1]);
		        for(j = 2; j < 4; j++) {
		        	if(mass[mass3[i]][j] != 0) {
			        	printf(", кв. %d (%d ш.е.)", mass3[i] * 4 + j + 1, mass[mass3[i]][j]);
			        }
		        }
	        }
	        else {
		        printf("кв. %d (%d ш.е.)", mass3[i] * 4 + 4, mass[mass3[i]][3]);
	        }
		}
		mass3[i] = 0;
	}
	printf("\n");
	printf("Дополнительное задание:\n"); //Начинаю выполнять дополнительное задание
	printf("Топ самых шумных этажей:\n");
	printf("1 место - Этаж ");
	q1 = 0; //сколько повторений значений первого места
	q1i = 0;
	q2 = 0; //сколько повторений значений второго места
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
	if(q1 >= 3) { //Если вдруг этажей с жильцами на первом месте хотя бы 3
		printf("%d (%d шум. ед., ближе): ", q1i + 1, mass2[q1i]); //Первое место
		if(mass[q1i][0] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", кв. %d (%d ш.е.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		for(i = 9; i > q1i; i--) {
			if(value == mass2[i]) {
				q1i1 = i;
			}
		}
		q1i = q1i1;
		printf("2 место - Этаж "); //Второе место
		printf("%d (%d шум. ед., дальше): ", q1i + 1, mass2[q1i]);
		if(mass[q1i][0] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", кв. %d (%d ш.е.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		for(i = 9; i > q1i; i--) {
			if(value == mass2[i]) {
				q1i1 = i;
			}
		}
		q1i = q1i1;
		printf("3 место - Этаж "); //Третье место
		printf("%d (%d шум. ед., ещё дальше): ", q1i + 1, mass2[q1i]);
		if(mass[q1i][0] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", кв. %d (%d ш.е.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
	}
	else if(q1 == 2) { //Если первое место разделяют 2 этажа
		printf("%d (%d шум. ед., ближе): ", q1i + 1, mass2[q1i]); //Первое место
		if(mass[q1i][0] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", кв. %d (%d ш.е.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		for(i = 9; i > q1i; i--) {
			if(value == mass2[i]) {
				q1i1 = i;
			}
		}
		q1i = q1i1;
		printf("2 место - Этаж "); //Второе место
		printf("%d (%d шум. ед., дальше): ", q1i + 1, mass2[q1i]);
		if(mass[q1i][0] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 2, mass[q1i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q1i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
		else if(mass[q1i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
				printf(", кв. %d (%d ш.е.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		printf("3 место - Этаж "); //Третье место
		printf("%d (%d шум. ед.): ", q2i + 1, mass2[q2i]);
		if(mass[q2i][0] != 0) {
			printf("кв. %d (%d ш.е.)", q2i * 4 + 1, mass[q2i][0]);
	    	for(i = 1; i < 4; i++) {
		    	if(mass[q2i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
	        	}
			}
		}
		else if(mass[q2i][1] != 0) {
			printf("кв. %d (%d ш.е.)", q2i * 4 + 2, mass[q2i][1]);
	    	for(i = 2; i < 4; i++) {
		    	if(mass[q2i][i] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
		        }
	        }
		}
		else if(mass[q2i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q2i * 4 + 3, mass[q2i][2]);
			if(mass[q2i][3] != 0) {
				printf(", кв. %d (%d ш.е.)", q2i * 4 + 4, mass[q2i][3]);
			}
		}
		printf("\n");
	}
	else {
		printf("%d (%d шум. ед.): ", q1i + 1, mass2[q1i]); //Первое место
		if(mass[q1i][0] != 0) {
		    printf("кв. %d (%d ш.е.)", q1i * 4 + 1, mass[q1i][0]);
	    	for(i = 1; i < 4; i++) {
		        if(mass[q1i][i] != 0) {
			        printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
	        	}
			}
		}
		else if(mass[q1i][1] != 0) {
		    printf("кв. %d (%d ш.е.)", q1i * 4 + 2, mass[q1i][1]);
	        for(i = 2; i < 4; i++) {
		        if(mass[q1i][i] != 0) {
			        printf(", кв. %d (%d ш.е.)", q1i * 4 + i + 1, mass[q1i][i]);
		        }
	        }
		}
	    else if(mass[q1i][2] != 0) {
			printf("кв. %d (%d ш.е.)", q1i * 4 + 3, mass[q1i][2]);
			if(mass[q1i][3] != 0) {
			    printf(", кв. %d (%d ш.е.)", q1i * 4 + 4, mass[q1i][3]);
			}
		}
		printf("\n");
		printf("2 место - Этаж ");
		if(q2 > 1) {	//Если второе место разделяют как минимум 2 этажа
		printf("%d (%d шум. ед., ближе): ", q2i + 1, mass2[q2i]); //Второе место
		    if(mass[q2i][0] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 1, mass[q2i][0]);
	    	    for(i = 1; i < 4; i++) {
		        	if(mass[q2i][i] != 0) {
			        	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
	            	}
			    }
		    }
		    else if(mass[q2i][1] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 2, mass[q2i][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			        	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
		            }
	            }
		    }
	    	else if(mass[q2i][2] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 3, mass[q2i][2]);
			    if(mass[q2i][3] != 0) {
				    printf(", кв. %d (%d ш.е.)", q2i * 4 + 4, mass[q2i][3]);
			    }
		    }
	    	printf("\n");
		    for(i = 9; i > q2i; i--) {
			    if(value1 == mass2[i]) {
				q1i1 = i;
			    }
		    }
		    q2i = q1i1;
		    printf("3 место - Этаж "); //Третье место
		    printf("%d (%d шум. ед., дальше): ", q2i + 1, mass2[q2i]);
		    if(mass[q2i][0] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 1, mass[q2i][0]);
	    	    for(i = 1; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			        	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
	        	    }
			    }
		    }
		    else if(mass[q2i][1] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 2, mass[q2i][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			        	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
		            }
	            }
		    }
	    	else if(mass[q2i][2] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 3, mass[q2i][2]);
			    if(mass[q2i][3] != 0) {
			    	printf(", кв. %d (%d ш.е.)", q2i * 4 + 4, mass[q2i][3]);
		    	}
		    }
		    printf("\n");
		}
		else { //Если первое место - 1 вариант, второе - тоже 1 вариант и 3 - 1 вариант
		    printf("%d (%d шум. ед.): ", q2i + 1, mass2[q2i]); //Второе место
		    if(mass[q2i][0] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 1, mass[q2i][0]);
	    	    for(i = 1; i < 4; i++) {
		            if(mass[q2i][i] != 0) {
			            printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
	                }
			    }
		    }
		    else if(mass[q2i][1] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 2, mass[q2i][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[q2i][i] != 0) {
			            	printf(", кв. %d (%d ш.е.)", q2i * 4 + i + 1, mass[q2i][i]);
		            }
	            }
		    }
	        else if(mass[q2i][2] != 0) {
			    printf("кв. %d (%d ш.е.)", q2i * 4 + 3, mass[q2i][2]);
			    if(mass[q2i][3] != 0) {
				    printf(", кв. %d (%d ш.е.)", q2i * 4 + 4, mass[q2i][3]);
			    }
		    }
	        printf("\n");
			printf("3 место - Этаж ");
			printf("%d (%d шум. ед.): ", ki + 1, mass2[ki]); //Третье место
		    if(mass[ki][0] != 0) {
			    printf("кв. %d (%d ш.е.)", ki * 4 + 1, mass[ki][0]);
	    	    for(i = 1; i < 4; i++) {
		            if(mass[ki][i] != 0) {
			                printf(", кв. %d (%d ш.е.)", ki * 4 + i + 1, mass[ki][i]);
	                }
			    }
		    }
		    else if(mass[ki][1] != 0) {
			    printf("кв. %d (%d ш.е.)", ki * 4 + 2, mass[ki][1]);
	    	    for(i = 2; i < 4; i++) {
		    	    if(mass[ki][i] != 0) {
			            printf(", кв. %d (%d ш.е.)", ki * 4 + i + 1, mass[ki][i]);
		            }
	            }
		    }
	        else if(mass[ki][2] != 0) {
			    printf("кв. %d (%d ш.е.)", ki * 4 + 3, mass[ki][2]);
			    if(mass[ki][3] != 0) {
				    printf(", кв. %d (%d ш.е.)", ki * 4 + 4, mass[ki][3]);
			    }
		    }
		}
	}
	
	return 0;
}