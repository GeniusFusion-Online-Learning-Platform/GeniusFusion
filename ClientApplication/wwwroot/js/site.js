$(document).ready(function () {
    let _facultiesUrl = 'https://localhost:7284/Faculties'; // Update the URL for the faculties API
    let _facultiesList = $('#facultiesList'); // Define the element to display faculties

    let writeMessage = function (msg) {
        // Function to display messages
        console.log(msg);
    };

    let loadFaculties = async function () {
        try {
            let resp = await fetch(_facultiesUrl, {
                method: 'GET',
                mode: 'cors',
                headers: {
                    'Accept': 'application/json'
                }
            });

            if (resp.ok) {
                let faculties = await resp.json();
                _facultiesList.empty();
                for (let i = 0; i < faculties.length; i++) {
                    // Construct HTML to display each faculty
                    let faculty = faculties[i];
                    let facultyInfo = `<li>${faculty.facultyName} - ${faculty.facultyEmail}</li>`;
                    _facultiesList.append(facultyInfo);
                }
            } else {
                writeMessage('Hmm, unable to fetch the faculties');
            }
        } catch (error) {
            console.error('Error while fetching faculties:', error);
            writeMessage('Error while fetching faculties');
        }
    };


    let addFaculty = async function (facultyData) {
        try {
            let response = await fetch(_facultiesUrl, {
                method: 'POST',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(facultyData) // Data to send in the request body
            });

            if (response.ok) {
                console.log('Faculty added successfully');
                // Reload the faculties list after adding a new faculty
                loadFaculties();
            } else {
                console.error('Failed to add faculty:', response.statusText);
            }
        } catch (error) {
            console.error('Error while adding faculty:', error);
        }
    };

    $('#addFacultyBtn').click(function () {
        let facultyData = {
            facultyName: $('#facultyNameInput').val(),
            dateOfBirth: $('#dateOfBirthInput').val(),
            facultyPhone: $('#facultyPhoneInput').val(),
            facultyAddress: $('#facultyAddressInput').val(),
            facultyEmail: $('#facultyEmailInput').val()
        };
        if (facultyData.facultyName) {
            addFaculty(facultyData);
        } else {
            console.error('Faculty name cannot be empty');
        }
    });





    // Call the loadFaculties function when the page loads
    loadFaculties();
});
 