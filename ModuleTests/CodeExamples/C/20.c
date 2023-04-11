#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <time.h>
#include <math.h>

int main(){

    SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

    srand(time(NULL));      //��������� ��������� �����

    int size = 0;     //���������� ��� ������� ������� ������� �������������
    int temp = 0;     //���������� ��� ���������� �������� ����������

    printf("����� ���������� � ���������!\n");
    fflush(stdout);
    printf("������� �������� ������ �������������� �������:");
    scanf("%d", &size);

    int *array = malloc(size * sizeof(int));    //�������� �������

    printf("������ ������ �������� %i\n", size);
    printf("������ ��������� ������� ���������:");


    for(int i = 0; i < size; i++){               //���� ��� ��������� � ������ �����
        temp = rand() % 200 + (-100);
        array[i] = temp;
        if(i < size && i != size - 1){
            printf(" %i", temp);
        }
        else if(i == size - 1){
            printf(" %i", temp);
        }
    }

    int max = array[0];                  //���������� ��� �������� ���������� � ���������� ��������
    int min = array[0];                   //� ���������� ��������
    int sum = 0;                                   //� ����� �������� ����� �������
    float average = 0;                             //� ������� �������� ����� �������
    int counter_max = 0;                       //� ���������� ����� ������������� ������� ��������������


    for(int i = 0; i < size; i++){           //���� ��� ����������� �����������, ����������� �����, ����� ��������� �������
        if(abs(max) < abs(array[i])){
            max = array[i];
        }

        if(min > array[i]){
            min = array[i];
        }

        sum += array[i];
    }

    average = sum / size;                    //����������� ��. �����.

    for(int i = 0; i < size; i++){           //������� ����� ������� ��. �����.
        if(array[i] > average){
            counter_max++;
        }
    }
    printf("\n���������� �� ������ �����: %i\n���������� �� �������� �����: %i\n������� ��������: %f\n���������� ����� ������� �������� ��������: %i\n", max, min, average, counter_max);
    return 0;
}
