//
//  main.c
//  pz_10
//
//  Created by Юра Елизаров on 16.11.2022.
//  П1) задаёт с помощью генератора случайных чисел количество жильцов для каждой
//  квартиры из диапазона от 0 до 6;
//  2) выводит на экран информацию о количестве проживающих в каждой квартире на
//  каждом этаже;
//  3) выводит информацию об этажах, находящихся на первых трех местах рейтинга
//  самых шумных этажей.
//

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>

int main(int argc, const char * argv[]) {
//  Переменные для дома
    int count_floors = 10;
    int count_apartments_by_floor = 4;
    
    struct floor {
        int floor_number;
        int apartments[4];
        int total_tenants;
    };
    
    struct floor house[10] = {};
    
//  "Строим" дом
    for (int floor = 0; floor < count_floors; floor++) {
        house[floor].floor_number = floor + 1;
        for (int apartment = 0; apartment < count_apartments_by_floor; apartment++) {
            house[floor].apartments[apartment] = rand()%7;
            house[floor].total_tenants += house[floor].apartments[apartment];
        }
    }
    
    
//  Вывод количества жильцов по этажам и квартирам
    for (int floor = count_floors - 1; floor >= 0; floor--) {
        printf("Этаж %d:", house[floor].floor_number);
        printf(" (%d шум. ед.):", house[floor].total_tenants);
        for (int apartment = 0; apartment < count_apartments_by_floor; apartment++) {
            printf(" %d", house[floor].apartments[apartment]);
        }
        printf("\n");
    }
    
    
    bool is_sorted = false;

    int i = 0;
    int sorted_floors = 0;
    int current_sorted_floors = 0;
    while (!is_sorted) {
        if (i + 1 < count_floors) {
            if (house[i].total_tenants < house[i + 1].total_tenants || (house[i].total_tenants == house[i + 1].total_tenants && house[i].floor_number > house[i+1].floor_number)) {
                struct floor floor_before = house[i];
                struct floor floor_after = house[i + 1];
                house[i] = floor_after;
                house[i+1] = floor_before;
            } else {
                current_sorted_floors++;
            }
            i++;
        } else {
            i = 0;
            current_sorted_floors = 0;
            sorted_floors++;
        }
        if (current_sorted_floors == count_floors - (sorted_floors + 1)) {
            is_sorted = true;
        }
    }
    printf("\n");
    
//  Вывод уровня шума
    for (int floor = 0; floor < 3; floor++) {
        printf("%d место - Этаж %d (%d шум. ед.", floor + 1, house[floor].floor_number, house[floor].total_tenants);
        if (floor < count_floors - 1 && house[floor].total_tenants == house[floor + 1].total_tenants) {
            printf(", ближе)");
        } else if (floor > 1 && house[floor - 1].total_tenants == house[floor].total_tenants) {
            printf(", дальше)");
        } else {
            printf(")");
        }
        printf(" (%d шум. ед.):", house[floor].total_tenants);
        for (int apartment = 0; apartment < count_apartments_by_floor; apartment++) {
            int appartment_number = (floor) * count_apartments_by_floor + (apartment + 1);
            printf("%sкв. %d (%d ш.е.)",apartment == 0 ? " " : ", ", appartment_number, house[floor].apartments[apartment]);
        }
        printf("\n");
    }
    
    printf("\n");
    
    return 0;
}
