using System;
using System.IO;

// Declare variables to hold animal data temporarily during entry
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// Variables used for control flow and input
int maxPets = 8;
string? readResult;
string menuSelection = "";
int petCount = 0;
string anotherPet = "y";
bool validEntry = false;
int petAge = 0;

// 2D array to store pet data: 8 pets max, each with 6 data fields
string[,] ourAnimals = new string[maxPets, 6];

// Pre-populate the array with initial animal entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "five";
            animalPhysicalDescription = "Small tiger sweet cat.";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "cat";
            animalID = "";
            animalAge = "2";
            animalPhysicalDescription = "Big hungry boy.";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    // Store the data into the array
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// Main menu loop
do
{
    Console.Clear();

    // Display menu options
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Handle menu selection
    switch (menuSelection)
    {
        case "1":
            // Display all pet records in the array
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Count current pets in the array
            anotherPet = "y";
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            // Allow user to add pets until the max limit is reached
            while (anotherPet == "y" && petCount < maxPets)
            {
                // Input: animal species (required)
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        validEntry = (animalSpecies == "dog" || animalSpecies == "cat");
                    }
                } while (!validEntry);

                // Generate a new ID using species prefix and pet count
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // Input: animal age (optional, allows "?")
                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        validEntry = animalAge == "?" || int.TryParse(animalAge, out petAge);
                    }
                } while (!validEntry);

                // Input: physical description (optional)
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                        validEntry = true;
                    }
                } while (!validEntry);

                // Input: personality description (optional)
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                        validEntry = true;
                    }
                } while (!validEntry);

                // Input: nickname (optional)
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                        validEntry = true;
                    }
                } while (!validEntry);

                // Save the new pet entry into the array
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount++;

                // Ask if the user wants to enter another pet
                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            // Inform user if the max limit has been reached
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure all pets have valid age and physical description
            for (int i = 0; i < maxPets; i++)
            {
                string id = ourAnimals[i, 0];
                string idValue = id.Replace("ID #: ", "").Trim();

                string age = ourAnimals[i, 2].Replace("Age: ", "").Trim();
                bool validAge = int.TryParse(age, out petAge);

                while (!validAge)
                {
                    Console.WriteLine($"Enter an age for ID #: {idValue}");
                    readResult = Console.ReadLine();

                    if (int.TryParse(readResult, out petAge))
                    {
                        ourAnimals[i, 2] = "Age: " + petAge.ToString();
                        validAge = true;
                    }
                }

                string description = ourAnimals[i, 4].Replace("Physical description: ", "").Trim();

                while (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine($"Enter a physical description for ID #: {idValue} (size, color, breed, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(readResult))
                    {
                        description = readResult.Trim();
                        ourAnimals[i, 4] = "Physical description: " + description;
                    }
                }
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure all pets have a nickname and personality description
            for (int i = 0; i < maxPets; i++)
            {
                string id = ourAnimals[i, 0];
                string idValue = id.Replace("ID #: ", "").Trim();

                if (string.IsNullOrWhiteSpace(idValue))
                    continue;

                string nickname = ourAnimals[i, 3].Replace("Nickname: ", "").Trim();
                while (string.IsNullOrWhiteSpace(nickname))
                {
                    Console.WriteLine($"Enter a nickname for ID #: {idValue}");
                    readResult = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(readResult))
                    {
                        nickname = readResult.Trim();
                        ourAnimals[i, 3] = "Nickname: " + nickname;
                    }
                }

                string personality = ourAnimals[i, 5].Replace("Personality: ", "").Trim();
                while (string.IsNullOrWhiteSpace(personality))
                {
                    Console.WriteLine($"Enter a personality description for ID #: {idValue} (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(readResult))
                    {
                        personality = readResult.Trim();
                        ourAnimals[i, 5] = "Personality: " + personality;
                    }
                }
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
        case "6":
        case "7":
        case "8":
            // Placeholder for features still in development
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");