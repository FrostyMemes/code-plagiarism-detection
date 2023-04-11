#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <time.h>
#include <math.h>

int main(){
    SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

    int house[10][4]; // массив жильцов дома
    int noise_pollution[10][4]; // массив уровн€ шума по квартирам
    int noise_amounts[10]; // массив уровн€ шума по этажам
    int householders_temp = 0; // временна€ переменна€ дл€ хранени€ информации о количестве человек в комнате
    int noise_temp = 0; // временна€ переменна€ дл€ зранени€ информации о шуме в комнате
    int noise = 0; // переменна€ дл€ хранени€ информации о шуме
    int average = 0; // переменна€ дл€ хранени€ информации о среднем значении
    int temp1 = 0; // временна€ переменна€ дл€ расчетов
    int counter = 0; // счетчик дл€ вывода “оп 3
    // установка случайной генерации чисел дл€ каждого запуска программы
    srand(time(NULL));
    printf("—писок числа жителей в доме по этажам и квартирам, а также шума, который они производ€т:\n");
    // цикл дл€ отображени€ информации о жильцах в общем
    for(int i = 10; i > 0; i--){
        printf("Ётаж %i: ", i);
        // вывод информации о жильцах на каждом этаже в доме
        for(int j = 0; j < 4; j++){
            householders_temp = rand() % 6;
            noise_temp = householders_temp * 2;
            house[i - 1][j] = (int*)householders_temp;
            noise_pollution[i - 1][j] = (int*)noise_temp;
            noise += noise_temp;
            // вывод по квартирам и уровню шума
            if(j < 4 && j != 3){
                printf("кв. %2i - %2i (%-2i ед.шума), ", ((i * 4) - 3 + j), house[i - 1][j], noise_pollution[i - 1][j]);
            }
            else if(j == 3){
                printf("кв. %2i - %2i (%-2i ед.шума) ", ((i * 4) - 3 + j), house[i - 1][j], noise_pollution[i - 1][j]);
            }
        }
        noise_amounts[i - 1] = noise; // запись уровн€ шума в массив
        noise = 0;
        average += (int)noise_amounts[i - 1]; // расчет среднего значени€ на основе суммы уровн€ шума по этажам (суммирование)
        printf("\n");
    }

    // цикл сортировки уровн€ шума по возрастанию (необходимо дл€ выставлени€ рейтинга топ 3)
    for(int i = 0; i < 10 - 1; i++){
        for(int j = 0; j < 10 - i - 1; j++){
            if(noise_amounts[j] < noise_amounts[j + 1]){
                temp1 = noise_amounts[j];
                noise_amounts[j] = noise_amounts[j + 1];
                noise_amounts[j + 1] = temp1;
            }
        }
    }

    temp1 = 0; // обнуление значени€ временной переменной
    average /= 10; // расчет среднего значени€

    printf("//////////////////\n–екордный уровень шума по этажам больше среднего значени€ - “оп 3\n");

    // цикл дл€ вывода информации о “оп 3 этажей по уровню шума, включа€ номер этажа, информацию по каждой из квартир
    for(int y = 0; y < 3; y++){
        for(int i = 0; i < 10; i++){
            if(noise_amounts[y] == (noise_pollution[i][0] + noise_pollution[i][1] + noise_pollution[i][2] + noise_pollution[i][3]) && counter < 3){
                printf("%i меcто -> %2i этаж - %2i единиц шума: ", y + 1, i + 1, noise_amounts[y]);

                for(int j = 0; j < 4; j++){
                    printf("кв. %2i - %2i (%-2i ед.шума), ", ((i * 4) + j), house[i][j], noise_pollution[i][j]);
                    noise_pollution[i][j] = 0;
                }

                counter++;

                printf("\n");
                exit;
            }
        }
    }

    return 0;
}
