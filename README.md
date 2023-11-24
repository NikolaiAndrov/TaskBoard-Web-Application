TaskBoard Web Application

This is an ASP.NET MVC (.NET 8) TaskBoard Web Application designed to manage tasks and organize them into specific boards. Users can create different tasks and pin them to one of three types of boards: "Open", "In Progress", and "Done".
Functionality

    Boards: Supports three types of boards: "Open", "In Progress", and "Done".
    Task Types: Each task can be associated with different types of buttons based on ownership:
        If the user is the owner of the task, buttons available are: "View", "Delete", and "Edit".
        The "Edit" functionality allows changes to the task's title, description, and status (changing the board of the task).
        If the user is not the owner of the task, only the "View" button is available.
    Home Page: Displays statistics about the tasks.

Usage

To use the TaskBoard web application:

    Registration/Login: Users must register and log in to use the application.
    Creating Tasks: Once logged in, users can create tasks and assign them to specific boards.
    Managing Tasks:
        Task Owners: Owners can view, delete, and edit their tasks.
        Non-Owners: Can only view tasks.

Setup
Prerequisites

    .NET 8 SDK
    Visual Studio (or another preferred code editor)

Installation

    Clone the repository.
    Open the solution file in Visual Studio.
    Restore NuGet packages and build the solution.

Running the Application

    Set the TaskBoard project as the startup project.
    Run the application.
