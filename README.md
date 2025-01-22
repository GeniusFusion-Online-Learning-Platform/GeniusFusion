GeniusFusion

GeniusFusion is an online learning platform developed using ASP.NET Core. It provides users with access to a wide range of courses, study materials, and tools for collaboration and progress tracking. The platform aims to deliver an exceptional learning experience for students, instructors, and administrators.

Features

For Students:

Browse and search for courses by topic, difficulty level, or instructor.

Enroll in courses and monitor learning progress.

Receive real-time notifications for deadlines, updates, and announcements.

Bookmark courses and lessons for future reference.

For Instructors:

Create, publish, and manage courses.

Grade assignments and provide responsive feedback.

Communicate with students through email integration.

Manage course settings and permissions.

For Administrators:

Manage user accounts and course catalogs.

Monitor platform analytics and maintain quality standards.

Control access permissions to ensure security and privacy compliance.

Additional Features:

Secure authentication with role-based access controls.

Real-time notifications for updates and emergencies.

Group formation capabilities to enhance collaboration.

Feedback collection for instructors and courses.

APIs

The platform is powered by a comprehensive set of APIs:

Authentication:

/register - Register a user with specific access levels.

/login - Verify credentials and grant access.

Course Management:

/add_course - Add new courses (Instructors/Admins only).

/update_course - Update course details.

/delete_course - Delete courses.

/fetch_course - Retrieve details of a single course.

/fetch_courses - Retrieve a list of all courses.

/enroll - Enroll students into courses.

Notifications:

/notify - Send real-time updates for events or deadlines.

Feedback and Reports:

/feedback - Submit feedback for instructors.

/generate_student_report - Generate academic performance reports (Admin only).

/generate_instructor_report - Generate instructor rating reports.

Utilities:

/search - Search for courses.

/bookmark - Bookmark courses for quick reference.

/email - Email integration for communication.

