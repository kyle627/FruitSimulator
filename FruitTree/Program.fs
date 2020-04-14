//Kyle Evanglisto
//4/14/2020
//prof aw
//Programming Part 3 Project 3
//Program 3/3

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
                printfn "It is most likely impossible to harvest that many apples in %s" numberDays
                printfn "days -- try harvesting less for this harvest"
                systemloop() //Call recursive function to gather proper input
        trees() 


        //formula to find tree yield for 1 year
        let fruitCount (x : float) = x * (48. / (0.30)) //approx 160 apples per tree (.30 representing wieght on one apple in lbs)
        //divide by 48 apples per brussel. Then multiplying that by the number of days the user is harvesting by. 

        //recursive function to help most accurately determine crop yield
        let rec treeCount (num : float) = 
            if num < 1. then 1.
            else (0.5 * num) + treeCount(num / 2.) //acounts for extra apples harvested in formula.

        let rec harvestLoop() = 
        
            let totalHarvest = fruitCount(numDaysFloat) * treeCount(numTreesFloat)
            //gets the total harvest by utilizing the fruitcount and treecount functions and multiplying them together
            //passes in the number of days to fruitcount and number of trees to tree count. 

            //output

            printf "In %s" numberDays 
            printf " days your harvest will be aproximately: %f" totalHarvest
            printf " apples!\n"
        
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

            printfn "What is the price per fruit your fruit sells at: please format in '0.89' for example"
            let priceperFruit = Console.ReadLine()
            let priceperFruitFloat = float priceperFruit //String --> Float

            let rec priceControl() =
                if priceperFruitFloat <= 0. then 
                    printfn "You won't make any money off this sale but okay."
            priceControl() //defines price control recursion 

            let total = (priceperFruitFloat : float) * (ammountSellingFloat : float)

            printf "The total you will make for your harvest is: "
            Console.WriteLine(total) //outputs the farmer's total harvest profit
            
        harvestLoop() //defines harvest recursion
        
        printf "Do you want to test another harvest? Enter = 'y' for yes or 'n' for no"
        let answer = Console.ReadLine()
        if answer = "y" then
            systemloop() //Call recursive function to re run the program
        else
           exit 0 //quit

    systemloop() //defines system recursion
    exit 0
    
    
    

    

