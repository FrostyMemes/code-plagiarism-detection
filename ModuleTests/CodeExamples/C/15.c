#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <locale.h>


int main(void)
{
	//k1, k2, k3 - Счётчики этажей с одинаковой шумностью
	//RoomsOnFloor - количество квартир на этаже, PeopleInRoom - кол-во людей в квартире, NoiseOnFloor - шумность на этаже, NumberOfFloor - номер этажа (для вывода в конце)
	//TopThree - Топ три этажа по шумности (Доп.), NumberOfTop - номера трех самых шумных этажей (Доп.)
	int k1, k2, k3, RoomsOnFloor;
	int PeopleInRoom[10][4];
	int NoiseOnFloor[10] = {0}; 
	int NumberOfFloor[10];
	int TopThree[4] = {0};
	int NumberOfTop[4] = {0};
	
	//Подключаем русский язык
	setlocale(LC_ALL, "Rus");

	srand(time(NULL));
	
	k1=0;
	k2=0;
	k3=0;
	
	//Заполнение квартир жильцами
	for (int n=0; n<10; n++) {
		for (int m=0; m<4; m++) {
			PeopleInRoom[n][m] = rand()%7;
		}
	}
	
	//Вывод кол-ва жильцов по этажам
	for (int n=9; n>-1; n--){
		printf("Этаж %d:", n+1);
		for (int m=0; m<4; m++) {
			printf(" %d", PeopleInRoom[n][m]);
		}
		printf("\n");
	}
	
	//Нахождение шумности этажа и заполнение номерами этажей
	for (int n = 0; n < 10; n++) {
		for (int m = 0; m < 4; m++) {
			NoiseOnFloor[n] += PeopleInRoom[n][m];
			NumberOfFloor[n] = n+1;
		}
	}
	
	//Сортировка этажей по шумности (Пузырьком)
	for (int i = 0; i < 10; i++) {
		for (int j = 9; j > i; j--) {
			if (NoiseOnFloor[j - 1] > NoiseOnFloor[j]) {
				int tmp = NoiseOnFloor[j - 1];
				NoiseOnFloor[j - 1] = NoiseOnFloor[j];
				NoiseOnFloor[j] = tmp;
				
				int tmpe = NumberOfFloor[j - 1];
				NumberOfFloor[j - 1] = NumberOfFloor[j];
				NumberOfFloor[j] = tmpe;
			}
		}
	}
	
	//Ииии первое место присуждается...
	printf("Список самых шумных этажей:\n");
	printf("1 место - Этаж %d (%d шумных единиц)", NumberOfFloor[9], NoiseOnFloor[9]);
	//Проверка на то, есть ли еще этажи с такой шумностью
	for(int i = 8; i >= 0; i--) {
		if (NoiseOnFloor[i] == NoiseOnFloor[9]) {
			printf(" и Этаж %d", NumberOfFloor[i]);
			k1++;
        } 
		else {
            break;
        }
    }
	printf(": ");
	//Вывод квартир по этажам
	for(int i = 0; i < k1+1; i++) {
                    
		//Всего на этаже 4 квартиры, поэтому учитываем это для запятых
		RoomsOnFloor = 4;
        for(int j = 0; j < 4; j++) {
            if (RoomsOnFloor > 1) {
                printf("кв.%d (%d ш.е.), ", (NumberOfFloor[9-i])*4-3+j, PeopleInRoom[NumberOfFloor[9-i]-1][j]);
                RoomsOnFloor--;
            } else if (RoomsOnFloor == 1) {
                printf("кв.%d (%d ш.е.)", (NumberOfFloor[9-i])*4-3+j, PeopleInRoom[NumberOfFloor[9-i]-1][j]);
            }
        }

        //Проверка на дополнительные этажи (чтобы ставилось "и")
        if (i+1 < k1+1) {
            printf(" и ");
        }
    }
	
	//Почётное второе место!!
	printf("\n");
	printf("2 место - Этаж %d (%d шумных единиц)", NumberOfFloor[8-k1], NoiseOnFloor[8-k1]);
	for(int i = 7-k1; i >= 0; i--){
		if (NoiseOnFloor[i] == NoiseOnFloor[8-k1]){
			printf(" и Этаж %d", NumberOfFloor[i], NoiseOnFloor[i]);
			k2++;
		} else {
			break;
		}
	}
	printf(": ");
	for(int i = 0; i < k2+1; i++){
		
		RoomsOnFloor = 4;
		for(int j = 0; j < 4; j++){
			if (RoomsOnFloor > 1){
				printf("кв.%d (%d ш.е.), ", (NumberOfFloor[9-1-k1-i])*4-3+j, PeopleInRoom[NumberOfFloor[8-k1-i]-1][j]);
				RoomsOnFloor--;
			} else if (RoomsOnFloor == 1){
				printf("кв.%d (%d ш.е.)", (NumberOfFloor[9-1-k1-i])*4-3+j, PeopleInRoom[NumberOfFloor[8-k1-i]-1][j]);
			}
		}
		if (i+1 < k2+1){
			printf(" и ");
		}
	}
	
	//и наконец третье место...
	printf("\n");
    printf("3 место - Этаж %d (%d шумных единиц)", NumberOfFloor[9-2-k1-k2], NoiseOnFloor[9-2-k1-k2]);
    for(int i = 6-k1-k2; i >= 0; i--){
        if (NoiseOnFloor[i] == NoiseOnFloor[9-2-k1-k2]){
            printf(" и Этаж %d", NumberOfFloor[i], NoiseOnFloor[i]);
            k3++;
        } else {
            break;
        }
    }
    printf(": ");
    for(int i = 0; i < k3+1; i++){
		
		RoomsOnFloor = 4;
        for(int j = 0; j < 4; j++){
            if (RoomsOnFloor > 1){
                printf("кв.%d (%d ш.е.), ", (NumberOfFloor[9-2-k1-k2-i])*4-3+j, PeopleInRoom[NumberOfFloor[7-k1-k2-i]-1][j]);
				RoomsOnFloor--;
            } else if (RoomsOnFloor == 1){
                printf("кв.%d (%d ш.е.)", (NumberOfFloor[9-2-k1-k2-i])*4-3+j, PeopleInRoom[NumberOfFloor[7-k1-k2-i]-1][j]);
            }
        }
        if (i+1 < k3+1){
            printf(" и ");
        }
    }
	
	printf("\n\n");
	printf("Дополнительное задание:\n");
	//Сортировка по близости к первому этажу
	for (int i = 0; i < 10; i++){
        for (int j = 9; j > i; j--){
            if ((NoiseOnFloor[j - 1] == NoiseOnFloor[j]) && (NumberOfFloor[j] > NumberOfFloor[j - 1])) {
                int temp2 = NumberOfFloor[j];
                NumberOfFloor[j] = NumberOfFloor[j - 1];
                NumberOfFloor[j - 1] = temp2;
            }
        }
    }
	
	for(int i = 0; i < 4; i++){
        TopThree[i] = NoiseOnFloor[9-i];
        NumberOfTop[i] = NumberOfFloor[9-i];
    }
	
	printf("Список самых шумных этажей:\n");
	
	//Первое дополнительное место!!
	if (TopThree[0]==TopThree[1]){
        printf("1 место - Этаж %d (%d шум. ед., ближе)", NumberOfTop[0], TopThree[0]);
    } else {
        printf("1 место - Этаж %d (%d шум. ед.)", NumberOfTop[0], TopThree[0]);
    }
	printf(": ");
	for(int i = 0; i < k1+1; i++) {
                    
		RoomsOnFloor = 4;
        for(int j = 0; j < 4; j++) {
            if (RoomsOnFloor > 1) {
                printf("кв.%d (%d ш.е.), ", (NumberOfTop[0])*4-3+j, PeopleInRoom[NumberOfTop[0]-1][j]);
                RoomsOnFloor--;
            } else if (RoomsOnFloor == 1) {
                printf("кв.%d (%d ш.е.)", (NumberOfTop[0])*4-3+j, PeopleInRoom[NumberOfTop[0]-1][j]);
            }
        }
    }
	
	//Второе место в допе-
	printf("\n");
	if (TopThree[0]==TopThree[1]){
        printf("2 место - Этаж %d (%d шум. ед., дальше)", NumberOfTop[1], TopThree[1]);
    } else if (TopThree[1]==TopThree[2]){
		printf("2 место - Этаж %d (%d шум. ед., ближе)", NumberOfTop[1], TopThree[1]);
	} else {
        printf("2 место - Этаж %d (%d шум. ед.)", NumberOfTop[1], TopThree[1]);
    }
	printf(": ");
	RoomsOnFloor = 4;
	for(int j = 0; j < 4; j++) {
        if (RoomsOnFloor > 1) {
            printf("кв.%d (%d ш.е.), ", (NumberOfTop[1])*4-3+j, PeopleInRoom[NumberOfTop[1]-1][j]);
            RoomsOnFloor--;
        } else if (RoomsOnFloor == 1) {
            printf("кв.%d (%d ш.е.)", (NumberOfTop[1])*4-3+j, PeopleInRoom[NumberOfTop[1]-1][j]);
        }
    }
	
	//И наконец завершающее третье место!
	printf("\n");
	if (TopThree[0]==TopThree[2]){
        printf("3 место - Этаж %d (%d шумных единиц, ещё дальше)", NumberOfTop[2], TopThree[2]);
    } else if (TopThree[1]==TopThree[2]){
		printf("3 место - Этаж %d (%d шум. ед., дальше)", NumberOfTop[2], TopThree[2]);
	} else if (TopThree[2]==TopThree[3]){
		printf("3 место - Этаж %d (%d шум. ед., ближе)", NumberOfTop[2], TopThree[2]);
	} else {
        printf("3 место - Этаж %d (%d шум. ед.)", NumberOfTop[2], TopThree[2]);
    }
	printf(": ");
	for(int i = 0; i < k1+1; i++) {
                    
		RoomsOnFloor = 4;
        for(int j = 0; j < 4; j++) {
            if (RoomsOnFloor > 1) {
                printf("кв.%d (%d ш.е.), ", (NumberOfTop[2])*4-3+j, PeopleInRoom[NumberOfTop[2]-1][j]);
                RoomsOnFloor--;
            } else if (RoomsOnFloor == 1) {
                printf("кв.%d (%d ш.е.)", (NumberOfTop[2])*4-3+j, PeopleInRoom[NumberOfTop[2]-1][j]);
            }
        }
    }
	
	//это был сущий ад...
	return 0;
}