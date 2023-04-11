#include <stdlib.h>
#include <stdio.h>
#include <windows.h>
#include <time.h>
#include <math.h>

int main(){
    SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

    int house[10][4]; // ������ ������� ����
    int noise_pollution[10][4]; // ������ ������ ���� �� ���������
    int noise_amounts[10]; // ������ ������ ���� �� ������
    int householders_temp = 0; // ��������� ���������� ��� �������� ���������� � ���������� ������� � �������
    int noise_temp = 0; // ��������� ���������� ��� �������� ���������� � ���� � �������
    int noise = 0; // ���������� ��� �������� ���������� � ����
    int average = 0; // ���������� ��� �������� ���������� � ������� ��������
    int temp1 = 0; // ��������� ���������� ��� ��������
    int counter = 0; // ������� ��� ������ ��� 3
    // ��������� ��������� ��������� ����� ��� ������� ������� ���������
    srand(time(NULL));
    printf("������ ����� ������� � ���� �� ������ � ���������, � ����� ����, ������� ��� ����������:\n");
    // ���� ��� ����������� ���������� � ������� � �����
    for(int i = 10; i > 0; i--){
        printf("���� %i: ", i);
        // ����� ���������� � ������� �� ������ ����� � ����
        for(int j = 0; j < 4; j++){
            householders_temp = rand() % 6;
            noise_temp = householders_temp * 2;
            house[i - 1][j] = (int*)householders_temp;
            noise_pollution[i - 1][j] = (int*)noise_temp;
            noise += noise_temp;
            // ����� �� ��������� � ������ ����
            if(j < 4 && j != 3){
                printf("��. %2i - %2i (%-2i ��.����), ", ((i * 4) - 3 + j), house[i - 1][j], noise_pollution[i - 1][j]);
            }
            else if(j == 3){
                printf("��. %2i - %2i (%-2i ��.����) ", ((i * 4) - 3 + j), house[i - 1][j], noise_pollution[i - 1][j]);
            }
        }
        noise_amounts[i - 1] = noise; // ������ ������ ���� � ������
        noise = 0;
        average += (int)noise_amounts[i - 1]; // ������ �������� �������� �� ������ ����� ������ ���� �� ������ (������������)
        printf("\n");
    }

    // ���� ���������� ������ ���� �� ����������� (���������� ��� ����������� �������� ��� 3)
    for(int i = 0; i < 10 - 1; i++){
        for(int j = 0; j < 10 - i - 1; j++){
            if(noise_amounts[j] < noise_amounts[j + 1]){
                temp1 = noise_amounts[j];
                noise_amounts[j] = noise_amounts[j + 1];
                noise_amounts[j + 1] = temp1;
            }
        }
    }

    temp1 = 0; // ��������� �������� ��������� ����������
    average /= 10; // ������ �������� ��������

    printf("//////////////////\n��������� ������� ���� �� ������ ������ �������� �������� - ��� 3\n");

    // ���� ��� ������ ���������� � ��� 3 ������ �� ������ ����, ������� ����� �����, ���������� �� ������ �� �������
    for(int y = 0; y < 3; y++){
        for(int i = 0; i < 10; i++){
            if(noise_amounts[y] == (noise_pollution[i][0] + noise_pollution[i][1] + noise_pollution[i][2] + noise_pollution[i][3]) && counter < 3){
                printf("%i ��c�� -> %2i ���� - %2i ������ ����: ", y + 1, i + 1, noise_amounts[y]);

                for(int j = 0; j < 4; j++){
                    printf("��. %2i - %2i (%-2i ��.����), ", ((i * 4) + j), house[i][j], noise_pollution[i][j]);
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
