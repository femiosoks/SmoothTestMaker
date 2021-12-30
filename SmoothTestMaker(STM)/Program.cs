using System;
using System.IO;


namespace SmoothTestMaker
{
    class Program
    {
        static Random generator = new Random();

        static void Main(string[] args)
        {
            //Main Program
            //Declaration of Variables for main Program.
            int response, trial = 0;
            bool parseAble;

            //Open line greetings 
            Console.WriteLine("Welcome to Smooth Test Maker!!!\n");
            string[] options = { "Press 1 to create a test", "Press 2 to take a test", "Press 3 to view results", "Press 0 to exit" };

            //Looping through array of options
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(options[i]);
            }

            //Checking for execptions and providing a limited number for trials.
            parseAble = int.TryParse(Console.ReadLine(), out response);
            while (!parseAble || response > 3)
            {
                if (trial < 3)
                {
                    Console.WriteLine("\nInvalid input");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(options[i]);
                    }
                    parseAble = int.TryParse(Console.ReadLine(), out response);
                    trial++;
                }
                else
                {
                    //Once trials are exhausted the program terminates
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }
            }

            //Assigning selected options to Procedures
            if (response == 1)
            {
                LoginOrSignUp();
                createTest();
            }

            else if (response == 2)
            {
                Console.Clear();
                takeTest();
            }

            else if (response == 3)
            {
                Console.Clear();
                Login();
                ViewResults();
            }
            //End of main program, all activities are done using only procedures.
        }


        //The start of createTest procedure
        static void createTest()
        {
            //Declaration of Variables for createTest Procedure.            
            int testNameTrial = 0, trial = 0, testNumber, randomNum, num = 1, answerCheckTrial = 0, questionCheckTrial = 0, i;
            string testID, questions, answers, testName, resultsFile, questionsfile, questionCheck, createNew, answerCheck, answersFile;
            bool parseAble;

            //Get preferred name for test
            Console.Write("\nEnter the preferred name of the test you would like to create: ");
            testName = Console.ReadLine();

            //verify if a key was entered and not a empty name, test name is limited to a key in order not to over control the creators choice.
            //loop to give three trials to the creator and end appliction if the user insists on not writing a name.
            while (testName.Length < 1)
            {
                if (testNameTrial < 3)
                {
                    Console.Write("\nInvalid input, desired name should have at least one key." +
                                  "\nEnter the preferred name of the test you would like to create: ");
                    testName = Console.ReadLine();
                    testNameTrial++;
                }
                else
                {
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }

            }

            //randomly generate a number between 000 to 999 and add it to the desired test name to create a testID          
            randomNum = generator.Next(000, 999);
            testID = testName + randomNum;

            //inform the test creator about their testID, and inform them on what to do with it
            Console.WriteLine("\nThis is a generated ID for your test: " + testID +
                              "\nKindly share it with potential respondents to give them access to your test." +
                              "\nThe TestID would also be needed to view results of test takers of this particular test.");

            //using the testID to create questions, answers and results File.
            questionsfile = testID + "QuestionsFile.txt";
            answersFile = testID + "AnswersFile.txt";
            resultsFile = testID + "ResultsFile.txt";
            StreamWriter testQuestions = new StreamWriter(questionsfile);
            StreamWriter testAnswers = new StreamWriter(answersFile);
            StreamWriter results = new StreamWriter(resultsFile, append: true);

            //Get how many numbers of questions test creators would like to set.
            Console.Write("\nHow many test questions would you like to set: ");

            //Verify if number is parsable, and loop through to give three extra trials 
            parseAble = int.TryParse(Console.ReadLine(), out testNumber);
            while (!parseAble || testNumber == 0)
            {
                if (trial < 3)
                {
                    Console.Write("\nInvalid input, response should be a number from 1 upwards." +
                                  "\nHow many test questions would you like to set: ");
                    parseAble = int.TryParse(Console.ReadLine(), out testNumber);
                    trial++;
                }
                else
                {
                    //notify user when they are out of trial, and exit the application.
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }
            }
            // Clear existing input on console to improve the usability of the user
            Console.Clear();

            // Brief user on how to use the application and inform them answers are not case-sensitive 
            Console.WriteLine("Great, here are examples of how to set questions and answers." +
                              "\n\nQuestion: What is 100/5? [A]25 [B]20 [C]95 [D] 50\nAnswer:B\nOR" +
                              "\nQuestion: What is the smallest planet in our solar system\nAnswer: Mercury" +
                              "\n\nNote: Answers are NOT Case-Sensitive and copy and paste of each line is allowed, Ctrl+V or Right Click to paste" +
                              "\nYou can now create your questions.");

            //loop through using the desired number of questions to write into both questions and answers file 
            for (i = 0; i < testNumber; i++)
            {
                //Display question number to improve usability of users and a count variable.
                questions = "\nQuestion " + num;
                answers = "Answer";

                //Get each question
                Console.Write(questions + ": ");
                questionCheck = Console.ReadLine();

                //loop through to verify at least two keys were written and give maximum of 5 trials
                while (questionCheck.Length < 2)
                {
                    if (questionCheckTrial < 5)
                    {
                        Console.Write("\nInvalid input, question set can not be less than 2 keys\n" +
                                        questions + ": ");
                        questionCheck = Console.ReadLine();
                        questionCheckTrial++;
                    }
                    else
                    {
                        //End application if user exhausted all 5 trials.
                        Console.WriteLine("\nOops! You are out of trials, try again later.");
                        Environment.Exit(0);
                    }

                }

                // Write checked questions intto the test question file.
                testQuestions.WriteLine(questionCheck);

                //Get each answer
                Console.Write(answers + ": ");
                answerCheck = Console.ReadLine();

                //loop through to verify at least one key was written and give maximum of 5 trials
                while (answerCheck.Length < 1)
                {
                    if (answerCheckTrial < 5)
                    {
                        Console.Write("\nInvalid input, answer set can not be less than a key\n" +
                                        answers + ": ");
                        answerCheck = Console.ReadLine();
                        answerCheckTrial++;
                    }
                    else
                    {
                        //End application if user exhausted all 5 trials.
                        Console.WriteLine("\nOops! You are out of trials, try again later.");
                        Environment.Exit(0);
                    }
                }

                // Write checked answers into the answer question file.
                testAnswers.WriteLine(answerCheck);

                //increment count variable for displaying question numbers
                num++;
            }

            // Close all files involved
            testQuestions.Close();
            testAnswers.Close();
            results.Close();

            // Inform test creator when test has been created successfully and reminding them of the testID and its importance
            //Also giving users the opportunity to create another test
            Console.Write("\nYou have successfully created your " + testName + " test." +
                               "\nDo not forget to share the test ID(" + testID + ") with potential respondents to give them access to your test." +
                               "\nThe TestID would also be needed to view results of test takers of this particular test." +
                               "\n\nWrite Y(es) to create another test or any key to end the application: ");
            createNew = Console.ReadLine();

            //Control for other options incase user did not really undersand what was required
            if (createNew.ToUpper() == "Y" || createNew.ToUpper() == "YES")
            {
                Console.Clear();
                createTest();
            }

            //End the application
            else
            {
                Environment.Exit(0);
            }

            //The end of Create test procedure
        }


        //The start of takeTest procedure
        static void takeTest()
        {
            //Declaration of Variables for createTest Procedure.
            string testChoice, testChoiceQuestionsFile, testChoiceAnswersFile, testChoiceResultsFile, response;
            string eachQuestion = "", eachAnswer = "", testTakerName, createNew, tryAgain;
            int score = 0, num = 1;

            //Get the test choice
            Console.Write("Please write the test ID of the test you would like to take: ");
            testChoice = Console.ReadLine();

            //using the testChoice to sort questions, answers and results File.
            testChoiceQuestionsFile = testChoice + "QuestionsFile.txt";
            testChoiceAnswersFile = testChoice + "AnswersFile.txt";
            testChoiceResultsFile = testChoice + "ResultsFile.txt";

            //Check if files exist
            if (File.Exists(testChoiceQuestionsFile) == true && File.Exists(testChoiceAnswersFile) == true)
            {
                StreamWriter results = new StreamWriter(testChoiceResultsFile, append: true);
                StreamReader testQuestions = new StreamReader(testChoiceQuestionsFile);
                StreamReader testAnswers = new StreamReader(testChoiceAnswersFile);

                // Clear existing input on console to improve the usability of the user
                Console.Clear();

                // Brief test takers on how to answer correctly and inform them answers are not case-sensitive 
                Console.WriteLine("Great, here are examples of how to answer questions." +
                             "\n\nQuestion: What is 100/5? [A]25 [B]20 [C]95 [D] 50: B\nOR" +
                             "\nQuestion: What is the smallest planet in our solar system: Mercury" +
                              "\n\nNote: Answers are NOT case-sensitive\nGoodluck.");

                //loop through to make questions available 
                while (testQuestions.EndOfStream == false)
                {
                    eachQuestion = testQuestions.ReadLine();
                    eachAnswer = testAnswers.ReadLine();
                    Console.Write("\nQuestion " + num + ": " + eachQuestion + ": ");
                    response = Console.ReadLine();

                    //Ensure it is not case sensitive
                    if (response.ToUpper() == eachAnswer.ToUpper())
                    {
                        score++;
                    }

                    num++;
                }

                //Get name of test takers
                Console.Write("\nWrite your name to view your score: ");
                testTakerName = Console.ReadLine();
                int testTakerNameTrial = 0;
                //Verify a name is entered and give 5 tials
                while (testTakerName.Length < 2)
                {
                    if (testTakerNameTrial < 5)
                    {
                        Console.Write("\nInvalid input, your name should have at least two keys." +
                                      "\nName: ");
                        testTakerName = Console.ReadLine();
                        testTakerNameTrial++;
                    }
                    else
                    {
                        //End application if user exhausted all 5 trials.
                        Console.WriteLine("\nOops! You are out of trials, try again later.");
                        Environment.Exit(0);
                    }

                }

                //Write date, time, name of test takers name and score into the result file
                results.WriteLine(DateTime.Now + ": " + testTakerName + ": " + score);

                //Inform the test takers of their score
                Console.WriteLine("\nHi " + testTakerName + ", you got " + score + " questions correctly." +
                                   "\n\nThank you for using Smooth Test Creator.");

                //Close all files involved
                testQuestions.Close();
                testAnswers.Close();
                results.Close();

                //Give users the opportunity to take another test
                Console.Write("\n\nWrite Y(es) to take another test or any key to end the application: ");
                createNew = Console.ReadLine();

                //Control for other options incase user did not really undersand what was required
                if (createNew.ToUpper() == "Y" || createNew.ToUpper() == "YES")
                {
                    Console.Clear();
                    takeTest();
                }

                else
                {
                    //End the application
                    Environment.Exit(0);
                }

            }

            //Control for if files were not found
            else if (File.Exists(testChoiceQuestionsFile) == false && File.Exists(testChoiceAnswersFile) == false)
            {
                //Inform users test were not found and give opportunity to try again.
                Console.Write("\nWe are sorry, the test cannot be found. " +
                              "\nPlease double-check the test ID or request for a valid test ID from the test creator." +
                              "\n\nWrite Y(es) to try again or any key to end the application: ");
                tryAgain = Console.ReadLine();

                //Control for other options incase user did not really undersand what was required
                if (tryAgain.ToUpper() == "Y" || tryAgain.ToUpper() == "YES")
                {
                    Console.Clear();
                    takeTest();
                }

                else
                {
                    Environment.Exit(0);
                }

                //The end of Take test procedure

            }
        }


        //The start of viewResults procedure
        static void ViewResults()
        {
            //Declaration of Variables for ViewResults Procedure.
            string testChoice, testResultFile, viewNew, tryAgain;

            //Get the test choice
            Console.Write("\nPlease write the test ID of the test you would like to view it results: ");
            testChoice = Console.ReadLine();

            //sort for the result file
            testResultFile = testChoice + "ResultsFile.txt";

            //Check if files exist
            if (File.Exists(testResultFile) == true)
            {
                //Check if someone has taken the test
                if (new FileInfo(testResultFile).Length == 0)
                {
                    //Inform user that no one has taken test and give opportunity to view another test results
                    Console.Write("\nNo one has taken your test\nWrite Y(es) to view another test \n Press any key to end the application: ");
                    viewNew = Console.ReadLine();

                    //Control for other options incase user did not really undersand what was required
                    if (viewNew.ToUpper() == "Y" || viewNew.ToUpper() == "YES")
                    {
                        Console.Clear();
                        ViewResults();
                    }

                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    //Read what is in the results file 
                    StreamReader results = new StreamReader(testResultFile);
                    Console.WriteLine("\nResults of " + testChoice);

                    //Loop through to read it all
                    while (results.EndOfStream == false)
                    {
                        string eachresult = results.ReadLine();
                        //Display results on Console
                        Console.WriteLine(eachresult);
                    }
                    //Close result file
                    results.Close();

                    //Give user opportunity to view another test results
                    Console.Write("\nWrite Y(es) to view another test or any key to end the application: ");
                    viewNew = Console.ReadLine();

                    //Control for other options incase user did not really undersand what was required
                    if (viewNew.ToUpper() == "Y" || viewNew.ToUpper() == "YES")
                    {
                        Console.Clear();
                        ViewResults();
                    }
                    else
                    {
                        //End the application
                        Environment.Exit(0);
                    }

                }
            }

            //Inform user if test results file not found and give the opportunity to try again
            else if (File.Exists(testResultFile) == false)
            {
                Console.Write("\nWe are sorry, the test results cannot be found. " +
                             "\nPlease double-check your test ID." +
                             "\n\nWrite Y(es) to try again or any key to end the application: ");
                tryAgain = Console.ReadLine();

                //Control for other options incase user did not really undersand what was required
                if (tryAgain.ToUpper() == "Y" || tryAgain.ToUpper() == "YES")
                {
                    Console.Clear();
                    ViewResults();
                }

                else
                {
                    //End the application
                    Environment.Exit(0);
                }
                //End of viewResults procedure.
            }
        }


        //Start of SignUp procedure
        static void SignUp()
        {
            //Declaration of Variables for SignUP Procedure.
            string Name, emailAddress, password, repeatedPassword, userFile, tryAgain;
            int nameTrial = 0, emailTrial = 0, passwordTrial = 0, repeatedPasswordTrial = 0;

            //Get name
            Console.Write("\tSign Up\n\nName: ");
            Name = Console.ReadLine();

            //Verify name is at least two keys and loop through to give 3 trials
            while (Name.Length < 2)
            {
                if (nameTrial < 3)
                {
                    //Inform user what is required
                    Console.Write("\nInvalid input, your name should have at least two keys." +
                                  "\nName: ");
                    Name = Console.ReadLine();
                    nameTrial++;
                }
                else
                {
                    //End application if user exhausted all 3 trials.
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }

            }
            //Get email
            Console.Write("\nEmail Address: ");
            emailAddress = (Console.ReadLine());

            //Verify email has at least six keys, @ sign and loop through to give 3 trials
            while (!emailAddress.Contains("@") || emailAddress.Length < 6)
            {
                if (emailTrial < 3)
                {
                    //Display error
                    Console.Write("\nOops! Email Address not recognized. Try again with a valid Email Address." +
                                  "\nEmail Address: ");
                    emailAddress = Console.ReadLine();
                    emailTrial++;
                }
                else
                {
                    //End application if user exhausted all 3 trials.
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }

            }

            //Get password with a minimum of six keys
            Console.Write("\n\t*Minimum of six keys Password. \nPassword: ");
            password = (Console.ReadLine());

            //Verified instructions obeyed and loop through to give three trials
            while (password.Length < 6)
            {
                if (passwordTrial < 3)
                {
                    //State instrutions again
                    Console.Write("\nInvalid input, Password cannot be less than six keys." +
                                  "\nPassword: ");
                    password = Console.ReadLine();
                    passwordTrial++;
                }
                else
                {
                    //End application if user exhausted all 3 trials.
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }

            }

            //Get confirmation of password
            Console.Write("\nRepeat Password: ");
            repeatedPassword = (Console.ReadLine());

            //Loop through to give three trials
            while (repeatedPassword != password)
            {
                if (repeatedPasswordTrial < 3)
                {
                    //Inform user what is expected
                    Console.Write("\nInvalid input, your repeated password has to match with your password." +
                                  "\nRepeat Password: ");
                    repeatedPassword = Console.ReadLine();
                    repeatedPasswordTrial++;
                }
                else
                {
                    //End application if user exhausted all 3 trials.
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }

            }


            //Combine email address and password to make a variable suitable for a file
            userFile = (emailAddress + password + ".txt");

            //Control of Users who try to create account twice with the same email address and password
            if (File.Exists(userFile) == true)
            {
                //Notify user they have created account and give they the option to be redirected to Login Menu
                Console.Write("\nOops! It seems you already have an account with us." +
                               "\n\nWrite Y(es) to go to login page or any key to end the application: ");

                //Control for other options incase user did not really undersand what was required
                tryAgain = Console.ReadLine();
                if (tryAgain.ToUpper() == "Y" || tryAgain.ToUpper() == "YES")
                {
                    Console.Clear();
                    Login();
                }

                else
                {
                    //End application
                    Environment.Exit(0);
                }
            }
            else
            {
                //Write User name into the file variable created
                File.WriteAllText(userFile, Name);
                Console.Clear();
            }
            //End of SignUp procedure.

        }

        //Start of Login procedure.
        static void Login()
        {
            //Declaration of Variables for Login Procedure.
            string emailAddress, password, userFile, name, tryAgain;

            //Get email address
            Console.Write("\tLogin\n\nEmail Address: ");
            emailAddress = (Console.ReadLine());

            //Get password
            Console.Write("\nPassword: ");
            password = (Console.ReadLine());

            //Sort for userfile
            userFile = (emailAddress + password + ".txt");

            // if user file found, open user file and greet user
            if (File.Exists(userFile) == true)
            {
                Console.Clear();
                StreamReader user = new StreamReader(userFile);
                name = user.ReadLine();
                Console.WriteLine("It is good to have you back " + name);
                user.Close();
            }

            //If user file not found notify Users that their details are incorrect, they should double check and give opportunity to try again
            else
            {
                Console.Write("\nIncorrect Details " +
                              "\nPlease double-check both password and email address" +
                              "\n\nWrite Y(es) to try again or any key to end the application: ");
                tryAgain = Console.ReadLine();

                //Control for other options incase user did not really undersand what was required
                if (tryAgain.ToUpper() == "Y" || tryAgain.ToUpper() == "YES")
                {
                    Console.Clear();
                    Login();
                }

                else
                {
                    //End the application
                    Environment.Exit(0);
                }
                //The end of Login procedure
            }
        }

        //The start of LoginOrSignUp procedure
        static void LoginOrSignUp()
        {
            //Declaration of Variables for Login Procedure.
            int userChoice, trial = 0;
            bool parseAble;


            // Clear existing input on console to improve the usability of the user 
            Console.Clear();
            string[] options = { "Press 1 to login", "Press 2 to sign up", "Press 0 to end the application" };

            //Loop through an options array to display login or sign up option
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(options[i]);
            }
            parseAble = int.TryParse(Console.ReadLine(), out userChoice);

            //Verify if number is parsable, and loop through to give three extra trials 
            while (!parseAble || userChoice > 2)
            {
                if (trial < 3)
                {
                    //Notify user for invalid input and loop through options array again
                    Console.WriteLine("\nInvalid input");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(options[i]);
                    }
                    parseAble = int.TryParse(Console.ReadLine(), out userChoice);
                    trial++;
                }

                else
                {
                    //End application if user exhausted all three trials.
                    Console.WriteLine("\nOops! You are out of trials, try again later.");
                    Environment.Exit(0);
                }

            }

            //Assigning selected options to Procedures
            if (userChoice == 1)
            {
                Console.Clear();
                Login();
            }
            else if (userChoice == 2)
            {
                Console.Clear();
                SignUp();
            }
            else
            {
                Environment.Exit(0);
            }

            //End of LoginOrSignup procedures and end of the Smooth Test Maker Version 1 . 
        }

    }

}






















