## Seed code - Boilerplate for step 5 - KeepNote Assignment

### Assignment Step Description

In this case study KeepNote Step 5, we will implement REST-based MicroServices with ASP.NET Core.
In this step, we will create this application in four parts 
    
        1. UserService
        2. CategoryService
        3. ReminderService
        4. NoteService 

### Steps to be followed:

    Step 1: Clone the boilerplate in a specific folder on your local machine.
    Step 2: Go thru the readme.md file and implement the code for UserService and run the test cases.
    Step 3: Go thru the readme.md file and implement the code for NoteService  and run the test cases.
    Step 4: Go thru the readme.md file and implement the code for CategoryService and run the test cases.
    Step 5: Go thru the readme.md file and implement the code for ReminderService and run the test cases.

### Project structure

The folders and files you see in this repositories, is how it is expected to be in projects, which are submitted for automated evaluation by Hobbes

    Project
	|
	├── NoteService                             // This is the microservice of Note   
	├── CategoryService                         // This is the microservice of Category   
	├── ReminderService                         // This is the microservice of Reminder   
	├── UserService                             // This is the microservice of User   
	├── .gitignore			                    // This file contains a list of file name that are supposed to be ignored by git 
	


#### To use this as a boilerplate for your new project, you can follow these steps

1. Clone the base boilerplate in the folder **assignment-solution-step5** of your local machine
     
    `git clone https://gitlab-cts.stackroute.in/aspnetcore/keepnote-step5-boilerplate.git assignment-solution-step5`

2. Navigate to assignment-solution-step5 folder

    `cd assignment-solution-step5`

3. Remove its remote or original reference

     `git remote rm origin`

4. Create a new repo in gitlab named `assignment-solution-step5` as private repo

5. Add your new repository reference as remote

     `git remote add origin https://gitlab-cts.stackroute.in/{{yourusername}}/aspnetcore_assignment-solution-step5`

     **Note: {{yourusername}} should be replaced by your username from gitlab**

5. Check the status of your repo 
     
     `git status`

6. Use the following command to update the index using the current content found in the working tree, to prepare the content staged for the next commit.

     `git add .`
 
7. Commit and Push the project to git

     `git commit -a -m "Initial commit | or place your comments according to your need"`

     `git push -u origin master`

8. Check on the git repo online, if the files have been pushed

### Important instructions for Participants
> - We expect you to write the assignment on your own by following through the guidelines, learning plan, and the practice exercises
> - The code must not be plagirized, the mentors will randomly pick the submissions and may ask you to explain the solution
> - The code must be properly indented, code structure maintained as per the boilerplate and properly commented
> - Follow through the problem statement shared with you
