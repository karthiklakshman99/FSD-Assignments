
## Objective
This exercise is created to get hands on with creating different component Lifecycle

## To Do
- Fork the boilerplate
- Clone the forked repository to local system
- Open terminal in forked project location and run `npm i` command to install dependency
- Follow the instruction in each `.js` file in components folder to complete the assignment

## Background
- When the application starts, state in `LifeCycleMount` will be initialized with default value
- When `componentDidMount` lifecycle is called state value is updated after 3 seconds (3000 ms)
- When the update happens in render method due to `componentDidMount` lifecycle. `componentDidUpdate` method will be called, which again changes the state value after 3 seconds (3000 ms)
- And atlast `componentWillUnmount` method will be called and changes the state value.

# Submitting your solution for preliminary automated review
- Open Hobbes and login into the platform
- Under Assignment repository select component-lifecycle, and branch master
- Under Your solution repository select your own repository and branch
- Press Submit
- Press click here for the feedback
- Evaluation will take around 5 mins to complete after which you need to refresh your browser and get the updated status
- Watch out for your total score and detailed status on each test and eslint errors in the coloured blocks on the screen
