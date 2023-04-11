#include <stdio.h>
#include <windows.h>
#include <stdlib.h>
#include <time.h>
#include <iso646.h>
#include <math.h>

float check_for_inputData;
float userInput, voidI;


int main(void){
	SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
	
    int userSize, check, absMax, minNum, sumArray, srznach, count, menuChoose,a;
    float userInput;
    
    menuChoose = 1;

    while (menuChoose != 0){
        printf("'ђ Ў®в  б ¬ ббЁў®¬'\n");
        printf("ѓ« ў­®Ґ ¬Ґ­о\n1. ‚лзЁб«Ґ­Ёп\n0. ‚ле®¤\n");
        
        while (scanf("%d", &menuChoose) != 1){
            printf("\n>> ‚ўҐ¤с­­®Ґ §­ зҐ­ЁҐ ­Ґ пў«пҐвбп жЁда®©\n\n");
            clear();
            printf("ѓ« ў­®Ґ ¬Ґ­о\n1. ‚лзЁб«Ґ­Ёп\n0. ‚ле®¤\n");
        }
        
        switch (menuChoose)
        {   
            case 1:
            {
                sumArray = 0;
                count = 0;
                printf("‡ ¤ ©вҐ а §¬Ґа ¬ ббЁў  ­ вга «м­л¬ зЁб«®¬:\n");
                userSize = inputData();
                int origArray[userSize];

                srand(time(NULL));
                for(int i = 0; i < userSize; i++){
                    origArray[i] = rand()%101 - 50;
                }
                printf("= = = =\n");
                printf("€бе®¤­л© ¬ ббЁў: ");
                for(int i = 0; i < userSize - 1; i++){
                    printf("%d, ", origArray[i]);
                }
                printf("%d\n", origArray[userSize-1]);
                printf("= = = =\n");

                for (int i = 0; i < userSize - 1; i++){
                    for (int j = (userSize - 1); j > i; j--){
                        if (origArray[j - 1] > origArray[j]) {
                            int temp = origArray[j - 1];
                            origArray[j - 1] = origArray[j];
                            origArray[j] = temp;
                        }
                    }
                }

                if (abs(origArray[0]) > abs(origArray[userSize-1])){
                    absMax = origArray[0];
                }
                if (abs(origArray[0]) < abs(origArray[userSize-1])){
                    absMax = origArray[userSize-1];
                }
                if (abs(origArray[0]) == abs(origArray[userSize-1])){
                    absMax = origArray[0];
                }
                

                minNum = origArray[0];

                for(int i = 0; i < userSize; i++){
                    sumArray += origArray[i];
                }

                srznach = sumArray/userSize;

                for(int i = 0; i < userSize; i++){
                    if (origArray[i] > srznach){
                        count++;
                    }
                }

                printf("1. “Ї®ап¤®з­л© Ї® ў®§а бв ­Ёо ¬ ббЁў: ");
                for(int i = 0; i < userSize - 1; i++){
                    printf("%d, ", origArray[i]);
                }
                printf("%d\n", origArray[userSize-1]);
                printf("2. Њ ЄбЁ¬ «м­л© Ї® ¬®¤г«о н«Ґ¬Ґ­в ¬ ббЁў : %d\n", absMax);
                printf("3. ЊЁ­Ё¬ «м­л© Ї® §­ зҐ­Ёо н«Ґ¬Ґ­в ¬ ббЁў : %d\n", minNum);
                printf("4. ‘аҐ¤­ҐҐ  аЁд¬ҐвЁзҐбЄ®Ґ н«Ґ¬Ґ­в®ў ¬ ббЁў  (ЋЄагЈ«Ґ­® ў ¬Ґ­миго бв®а®­г): %d\n", srznach);
                printf("5. Љ®«-ў® н«Ґ¬Ґ­в®ў ¬ ббЁў , §­ зҐ­ЁҐ Є®в®але Ў®«миҐ баҐ¤­ҐЈ®  аЁд¬ҐвЁзҐбЄ®Ј®: %d\n", count);
                printf("= = = =\n");
                printf(">> —в®Ўл ўҐа­гвбп ў Ј« ў­®Ґ ¬Ґ­о, ўўҐ¤ЁвҐ «оЎ®© бЁ¬ў®«\n");
                scanf("%d", &a);
                clear();
                break;
            }
        }
    }

    return 0; 
}

int inputData(void){
    check_for_inputData = scanf("%f", &userInput);
    while ((check_for_inputData != 1) or (modff(userInput, &voidI) != 0) or (userInput <= 0)){ 
        if (check_for_inputData != 1) {   
            printf(">> ‚ўҐ¤с­­®Ґ §­ зҐ­ЁҐ ­Ґ пў«пҐвбп жЁда®©\n");
        } else if (userInput <= 0){
            printf(">> ‚ўҐ¤с­­®Ґ §­ зҐ­ЁҐ ­Ґ ­ вга «м­л¬ зЁб«®¬\n");    
        }
        else {
            printf(">> ‚ўҐ¤с­­®Ґ §­ зҐ­ЁҐ ­Ґ пў«пҐвбп жҐ«®© жЁда®©\n");   
        }
        clear();
        check_for_inputData = scanf("%f", &userInput);
    }
    return userInput;
}

int clear(void){
    while ( getchar() != '\n' );
}