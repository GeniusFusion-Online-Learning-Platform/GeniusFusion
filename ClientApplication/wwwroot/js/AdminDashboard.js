$(document).ready(function () {
    // Function to fetch student details by ID
    function fetchStudentDetails(studentId) {
        $.ajax({
            type: "GET",
            url: "https://localhost:7284/Students/" + studentId,
            contentType: "application/json",
            success: function (student) {
                var details = '<p>ID: ' + student.studentId + '</p>' +
                    '<p>Name: ' + student.studentName + '</p>' +
                    '<p>Date of Birth: ' + student.dateOfBirth + '</p>' +
                    '<p>Phone: ' + student.studentPhone + '</p>' +
                    '<p>Address: ' + student.studentAddress + '</p>' +
                    '<p>Email: ' + student.studentEmail + '</p>';
                $('#studentDetails').html(details);

                // Redirect to ShowStudentById page after fetching details
                window.location.href = '/Home/ShowStudentById?id=' + studentId;
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });
    }

    function fetchFacultyDetails(facultyId) {
        $.ajax({
            type: "GET",
            url: "https://localhost:7284/Faculties/" + facultyId,
            contentType: "application/json",
            success: function (faculty) {
                var details = '<p>ID: ' + faculty.facultyId + '</p>' +
                    '<p>Name: ' + faculty.facultyName + '</p>' +
                    '<p>Date of Birth: ' + faculty.dateOfBirth + '</p>' +
                    '<p>Phone: ' + faculty.facultyPhone + '</p>' +
                    '<p>Address: ' + faculty.facultyAddress + '</p>' +
                    '<p>Email: ' + faculty.facultyEmail + '</p>';
                $('#facultyDetails').html(details);

                window.location.href = '/Home/ShowFacultyById?id=' + facultyId;
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });
    }

    // Event listener for toggling manageFacultiesDiv
    $('#manageFacultiesBtn').click(function () {
        $('#manageFacultiesDiv').toggle();
    });

    // Event listener for creating a faculty
    $('#createFacultyBtn').click(function () {
        // Redirect to create faculty page
        window.location.href = '/Home/Faculty';
    });

    $('#getFacultiesBtn').click(function () {
        // Redirect to the ShowAllStudents page
        window.location.href = '/Home/ShowAllFaculties';
    });
    $('#getFacultiesByIdBtn').click(function () {
        var facultyId = prompt('Enter Faculty ID:');
        if (facultyId) {
            fetchFacultyDetails(facultyId);
        }
        
    });

    $('#getCoursesBtn').click(function () {
        window.location.href = '/Home/ShowAllCourses';
    });
    $('#deleteCourseBtn').click(function () {
        window.location.href = '/Home/DeleteCourse';
    });
    $('#deleteFacultyBtn').click(function () {
        var facultyId = prompt('Enter Faculty ID:');
        if (facultyId) {
            window.location.href = '/Home/DeleteFaculty?id=' + facultyId;
        }
    });

    // Event listener for managing students button
    $('#manageStudentsBtn').click(function () {
        $('#manageStudentsDiv').toggle();
    });

    // Event listener for creating a student
    $('#createStudentBtn').click(function () {
        // Redirect to create student page
        window.location.href = '/Home/CreateStudent';
    });

    // Event listener for getting all students
    $('#getStudentsBtn').click(function () {
        // Redirect to the ShowAllStudents page
        window.location.href = '/Home/ShowAllStudents';
    });

    // Event listener for manual student ID input and fetching details
    $('#getStudentByIdBtn').click(function () {
        var studentId = prompt('Enter student ID:');
        if (studentId) {
            fetchStudentDetails(studentId);
        }
    });


    // Event listener for deleting a student
    $('#deleteStudentBtn').click(function () {
        var studentId = prompt('Enter student ID:');
        if (studentId) {
            // Redirect to delete student page with the provided student ID
            window.location.href = '/Home/DeleteStudent?id=' + studentId;
        }
    });

    // Event listener for toggling manageCoursesDiv
    $('#manageCoursebtn').click(function () {
        $('#manageCoursesDiv').toggle();
    });

    // Event listener for creating a course
    $('#assignCourseBtn').click(function () {
        var courseName = prompt('Enter Course Name:');
        var facultyId = prompt('Enter Faculty ID:');
        if (courseName && facultyId) {
            console.log("Course Name:", courseName); // Debugging statement
            console.log("Faculty ID:", facultyId);
            $.ajax({
                type: "POST",
                url: "https://localhost:7284/Course",
                contentType: "application/json", 

                data:JSON.stringify( {
                    courseName: courseName,
                    facultyId: facultyId
                }),
                success: function () {
                    alert('Course created successfully.');
                },
                error: function (xhr, status, error) {
                    console.error("Error creating course:", xhr.responseText);
                    alert('Error creating course. Please try again.');
                }
            });
        }
    });
});


//$(document).ready(function () {
//    // Function to fetch student details by ID
//    function fetchStudentDetails(studentId) {
//        $.ajax({
//            type: "GET",
//            url: "https://localhost:7284/Students/" + studentId,
//            contentType: "application/json",
//            success: function (student) {
//                var details = '<p>ID: ' + student.studentId + '</p>' +
//                    '<p>Name: ' + student.studentName + '</p>' +
//                    '<p>Date of Birth: ' + student.dateOfBirth + '</p>' +
//                    '<p>Phone: ' + student.studentPhone + '</p>' +
//                    '<p>Address: ' + student.studentAddress + '</p>' +
//                    '<p>Email: ' + student.studentEmail + '</p>';
//                $('#studentDetails').html(details);

//                // Redirect to ShowStudentById page after fetching details
//                window.location.href = '/Home/ShowStudentById?id=' + studentId;
//            },
//            error: function (xhr, status, error) {
//                console.log(xhr.responseText);
//            }
//        });
//    }

//    function fetchFacultyDetails(facultyId) {
//        $.ajax({
//            type: "GET",
//            url: "https://localhost:7284/Faculties/" + facultyId,
//            contentType: "application/json",
//            success: function (faculty) {
//                var details = '<p>ID: ' + faculty.facultyId + '</p>' +
//                    '<p>Name: ' + faculty.facultyName + '</p>' +
//                    '<p>Date of Birth: ' + faculty.dateOfBirth + '</p>' +
//                    '<p>Phone: ' + faculty.facultyPhone + '</p>' +
//                    '<p>Address: ' + faculty.facultyAddress + '</p>' +
//                    '<p>Email: ' + faculty.facultyEmail + '</p>';
//                $('#facultyDetails').html(details);

//                window.location.href = '/Home/ShowFacultyById?id=' + facultyId;
//            },
//            error: function (xhr, status, error) {
//                console.log(xhr.responseText);
//            }
//        });
//    }

//    function generateRandomChart() {
//        // Generate random data for the chart
//        var data = {
//            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
//            datasets: [{
//                label: '# of Votes',
//                data: [12, 19, 3, 5, 2, 3],
//                backgroundColor: [
//                    'rgba(255, 99, 132, 0.2)',
//                    'rgba(54, 162, 235, 0.2)',
//                    'rgba(255, 206, 86, 0.2)',
//                    'rgba(75, 192, 192, 0.2)',
//                    'rgba(153, 102, 255, 0.2)',
//                    'rgba(255, 159, 64, 0.2)'
//                ],
//                borderColor: [
//                    'rgba(255, 99, 132, 1)',
//                    'rgba(54, 162, 235, 1)',
//                    'rgba(255, 206, 86, 1)',
//                    'rgba(75, 192, 192, 1)',
//                    'rgba(153, 102, 255, 1)',
//                    'rgba(255, 159, 64, 1)'
//                ],
//                borderWidth: 1
//            }]
//        };

//        // Chart configuration
//        var options = {
//            scales: {
//                y: {
//                    beginAtZero: true
//                }
//            }
//        };

//        // Render the chart
//        var ctx = document.getElementById('studentChart').getContext('2d');
//        var myChart = new Chart(ctx, {
//            type: 'bar',
//            data: data,
//            options: options
//        });
//    }
//    $(document).ready(function () {
//        // Function to toggle manageStudentsDiv
//        $('#manageStudentsBtn').click(function () {
//            $('#manageStudentsDiv').toggle();
//        });

//    // Event listener for toggling manageFacultiesDiv
//    $('#manageFacultiesBtn').click(function () {
//        $('#manageFacultiesDiv').toggle();
//    });

//    // Event listener for toggling manageCoursesDiv
//    $('#manageCoursebtn').click(function () {
//        $('#manageCoursesDiv').toggle();
//    });

//    // Event listener for creating a faculty
//    $('#createFacultyBtn').click(function () {
//        // Redirect to create faculty page
//        window.location.href = '/Home/AddFaculty';
//    });

//    $('#getFacultiesBtn').click(function () {
//        // Redirect to the ShowAllStudents page
//        window.location.href = '/Home/ShowAllFaculties';
//    });

//    $('#deleteFacultyBtn').click(function () {
//        var facultyId = prompt('Enter Faculty ID:');
//        if (facultyId) {
//            window.location.href = '/Home/DeleteFaculty?id=' + facultyId;
//        }
//    });

//    // Event listener for managing students button
//    $('#manageStudentsBtn').click(function () {
//        $('#manageStudentsDiv').toggle();
//    });

//    // Event listener for creating a student
//    $('#createStudentBtn').click(function () {
//        // Redirect to create student page
//        window.location.href = '/Home/CreateStudent';
//    });

//    // Event listener for getting all students
//    $('#getStudentsBtn').click(function () {
//        // Redirect to the ShowAllStudents page
//        window.location.href = '/Home/ShowAllStudents';
//    });

//    // Event listener for manual student ID input and fetching details
//    $('#getStudentByIdBtn').click(function () {
//        var studentId = prompt('Enter student ID:');
//        if (studentId) {
//            fetchStudentDetails(studentId);
//        }
//    });

//    // Event listener for updating a student
//    $('#updateStudentBtn').click(function () {
//        var studentId = prompt('Enter student ID:');
//        if (studentId) {
//            // Redirect to update student page with the provided student ID
//            window.location.href = '/Home/EditStudent?id=' + studentId;
//        }
//    });

//    // Event listener for deleting a student
//    $('#deleteStudentBtn').click(function () {
//        var studentId = prompt('Enter student ID:');
//        if (studentId) {
//            // Redirect to delete student page with the provided student ID
//            window.location.href = '/Home/DeleteStudent?id=' + studentId;
//        }
//    });

//    // Ajax request for creating a course
//    $('#assignCourseBtn').click(function () {
//        var courseName = prompt('Enter Course Name:');
//        var facultyId = prompt('Enter Faculty ID:');
//        if (courseName && facultyId) {
//            console.log("Course Name:", courseName); // Debugging statement
//            console.log("Faculty ID:", facultyId);
//            $.ajax({
//                type: "POST",
//                url: "https://localhost:7284/Course",
//                data: {
//                    courseName: courseName,
//                    facultyId: facultyId
//                },
//                success: function () {
//                    alert('Course created successfully.');
//                },
//                error: function (xhr, status, error) {
//                    console.error("Error creating course:", xhr.responseText);
//                    alert('Error creating course. Please try again.');
//                }
//            });
//        }
//    });

//});


