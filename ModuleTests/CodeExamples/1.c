#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <locale.h>
#include <time.h>

int main(void) {

    setlocale(LC_ALL,"Russian");

    //Инициализация переменных
    srand(time(NULL));
    char array[10][4];
    char anoise[10];

    int y = 0, x = 0;
    int noise = 0, noise_1 = 0, noise_2 = 0, noise_3 = 0, noise_lim;

    //Заполнение квартир и вывод квартир таблицей
    while(y != 10) {
        printf("Этаж %2d: ", y + 1);
        array[y][0] = rand() % 7;
        array[y][1] = rand() % 7;
        array[y][2] = rand() % 7;
        array[y][3] = rand() % 7;
        printf("%d %d %d %d \n", array[y][0], array[y][1], array[y][2], array[y][3]);
        anoise[y] = array[y][0] + array[y][1] + array[y][2] + array[y][3];
        y++;
    }

//вывод топа этажей
    printf("Топ этажей: \n");
    //1 место
    y = 0;
    while(y != 10) {
        if(anoise[y] > noise) {
            noise = anoise[y];
            noise_1 = y;
        }
        y++;
    }
    printf("1 Место:");
    y = 0;
    while(y != 10) {
        if(anoise[y] == noise) {
            printf(" %d(%d Ед. шума)", y + 1, noise);
        }
        y++;
    }
    noise_lim = noise;
    noise = 0;

    //2 место
    y = 0;
    while(y != 10) {
        if((anoise[y] > noise) && (anoise[y] < noise_lim)) {
            noise = anoise[y];
            noise_2 = y;
        }
        y++;
    }
    printf("\n2 Место:");
     y = 0;
    while(y != 10) {
        if(anoise[y] == noise) {
            printf(" %d(%d Ед. шума)", y + 1, noise);
        }
        y++;
    }
    noise_lim = noise;
    noise = 0;

    //3 место
    y = 0;
    while(y != 10) {
        if((anoise[y] > noise) && (anoise[y] < noise_lim)) {
            noise = anoise[y];
            noise_3 = y;
        }
        y++;
    }
    printf("\n3 Место:");
     y = 0;
    while(y != 10) {
        if(anoise[y] == noise) {
            printf(" %d(%d Ед. шума)", y + 1, noise);
        }
        y++;
    }
    noise = 0;

//вывод топа этажей (доп. задание)
    noise = 0, noise_1 = 0, noise_2 = 0, noise_3 = 0;
    printf("\nДоп. задание: \n");

    //1 место
    y = 0;
    while(y != 10) {
        if(anoise[y] > noise) {
            noise = anoise[y];
            noise_1 = y;
        }
        y++;
    }
    printf("1 Место - Этаж %d(%d Ед. шума)\n", noise_1 + 1, noise);
    noise = 0;

    //2 место
    y = 0;
    while(y != 10) {
        if(y == noise_1) {
            y++;
        }
        if(anoise[y] > noise) {
            noise = anoise[y];
            noise_2 = y;
        }
        y++;
        if(y == noise_1) {
            y++;
        }
    }
    printf("2 Место - Этаж %d(%d Ед. шума)\n", noise_2 + 1, noise);
    noise = 0;

    //3 место
    y = 0;
    while(y != 10) {
        if((y == noise_1) || (y == noise_2)) {
            y++;
        }
        if((y == noise_1) || (y == noise_2)) {
            y++;
        }
        if(anoise[y] > noise) {
            noise = anoise[y];
            noise_3 = y;
        }
        y++;
        if((y == noise_1) || (y == noise_2)) {
            y++;
        }
        if((y == noise_1) || (y == noise_2)) {
            y++;
        }
    }
    printf("3 Место - Этаж %d(%d Ед. шума)\n", noise_3 + 1, noise);
    noise = 0;

    return 0;
}