//Kyle Evanglisto
//4/14/2020 -> 4/15/2020
//prof aw
//Programming Part 3 Project 3
//Program 3/3
//No mutable variables were used 

open System

[<EntryPoint>]
let main argv =
    //Initiate system loop
    let rec systemloop() =
        
        //User Instruction
        printfn "Lets pretend you are a fruit tree farmer and you are trying to figure out what your harvest will yield."
        printfn "Enter the amount of days your harvest will be: "
        //Input the amount of years speciied by the user.
    
        let numberDays = Console.ReadLine()
        let numDaysFloat = float numberDays //String --> Float
        let rec days() = 
            if numDaysFloat > 10. then
                 printfn "Your crops have probably spoilt by then, try harvesting for a shorter amount of time."
                 systemloop() //Call recursive function to gather proper input
        days()

        //User Instruction
        printfn "Enter the amount of trees are on your farm: "
        //Input the amount of trees speciied by the user.
        let numberTrees = Console.ReadLine()
        let numTreesFloat = float numberTrees //String --> Float
        let rec trees() =
            if numTreesFloat > 500. then
                printfn "It is most likely impossible to harvest that many fruits in %s" numberDays
                printfn "days -- try harvesting less for this harvest"
                systemloop() //Call recursive function to gather proper input
        trees() 


        //formula to find tree yield for 1 full harvest
        let fruitCount (x : float) = x * (48.0 / (0.20)) //approx 160 apples per ONE -- more trees, more fruits -- tree (.20 representing wieght on one fruit in lbs)
        //divide by 48 apples per brussel. Then multiplying that by the number of days the user is harvesting by. 

        //recursive function to help most accurately determine crop yield
        let rec treeCount (num : float) = 
            if num < 1. then 1.
            else (0.5 * num) + treeCount(num / 2.) //acounts for extra fruits harvested in formula. Not every harvest has a cookie cutter number of fruits

        let rec harvestLoop() = 
        
            let totalHarvest = fruitCount(numDaysFloat) * treeCount(numTreesFloat)
            //gets the total harvest by utilizing the fruitcount and treecount functions and multiplying them together
            //passes in the number of days to fruitcount and number of trees to tree count. 

            //output

            printf "In %s" numberDays 
            printf " days your harvest will be aproximately: %f" totalHarvest
            printf " fruits!\n"
        
            //part 2

            printfn "Let's figure out how much of a profit you will make from the harvest."
            printfn "Enter in the amount of you harvest that you want to sell. Remember, your harvest was: %f" totalHarvest
            let amountSelling = Console.ReadLine()
            let ammountSellingFloat = float amountSelling //String --> Float

            let rec overHarvestControl() = 
                if ammountSellingFloat > totalHarvest then 
                    printf "You don't have that many to sell!"
                    harvestLoop() //Call recursive function to gather proper input
            overHarvestControl() //defines the over harvest control recursion

            let rec fruitMatchingCheck()=
                printfn "What type of fruit are you selling? Enter (1 , 2 , or 3) Only choose 1"
                printfn "\n1.Apples\n2.Cherries\n3.Peaches"
                let typeFruit = Console.ReadLine()
                //type matching to determine what type of fruit the farmer has
                //each fruit is worth a different amount, so depending on what trees the farmer hazrvests will yield a different profit
                match typeFruit with
                |"1"->printfn"Your total profit will be: %f" (ammountSellingFloat * 0.89) //0.89 represents apple price
                |"2"->printfn"Your total profit will be: %f" (ammountSellingFloat * 0.62) //0.62 represents cherry price
                |"3"->printfn"Your total profit will be: %f" (ammountSellingFloat * 0.78) // 0.78 represents peach price
            fruitMatchingCheck()
            
        harvestLoop() //defines harvest recursion
        
        printf "Do you want to test another harvest? Enter = 'y' for yes or 'n' for no  "
        let answer = Console.ReadLine()
        match answer with
        |"yes"-> systemloop()   
        |"y"-> systemloop()
        |"Y"-> systemloop()
        |"Yes"->systemloop()
        |"no"->exit 0
        |"n" -> exit 0
        |"No"-> exit 0
        |"N"-> exit 0
        


    systemloop() //defines system recursion
    exit 0
    
    
    

    

