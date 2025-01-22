$(document).ready(function () {
    // Function to fetch all courses and display them
    function getAllCourses() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7284/Course",
            contentType: "application/json",
            success: function (courses) {
                console.log("All courses:", courses);
                displayCourses(courses);
            },
            error: function (xhr, status, error) {
                console.error("Error fetching courses:", xhr.responseText);
                // Handle error, show alert, etc.
            }
        });
    }

    // Function to dynamically display courses
    function displayCourses(courses) {
        var container = $(".course-container");

        // Clear the container before adding new courses to avoid duplication
        container.empty();

        // Loop through each course and create HTML elements to display them
        $.each(courses, function (index, course) {
            // Create anchor tag wrapping the course card
            var anchor = $("<a>").attr("href", "CourseInfo?id=" + course.courseId);
            var card = $("<div>").addClass("course-card");
            var image = $("<img>").addClass("course-image").attr("src", "/images/logo.png");
            var id = $("<h5>").addClass("course-id").text("ID: " + course.courseId);
            var name = $("<p>").addClass("course-name").text("Name: " + course.courseName);

            // Append image, id, and name to the card
            card.append(image, id, name);

            // Append card to the anchor tag
            anchor.append(card);

            // Append anchor tag to the container
            container.append(anchor);
        });
    }

    // Call the function to fetch and display all courses
    getAllCourses();

