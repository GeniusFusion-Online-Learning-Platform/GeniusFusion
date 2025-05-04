# GeniusFusion

**GeniusFusion** is an online learning platform developed using **ASP.NET Core**. It offers access to a wide range of courses, study materials, and tools for collaboration and progress tracking. The platform is designed to provide an exceptional learning experience for students, instructors, and administrators.

---

## 🚀 Features

### 👩‍🎓 For Students
- Browse and search for courses by topic, difficulty level, or instructor
- Enroll in courses and monitor learning progress
- Receive real-time notifications for deadlines, updates, and announcements
- Bookmark courses and lessons for future reference

### 👨‍🏫 For Instructors
- Create, publish, and manage courses
- Grade assignments and provide responsive feedback
- Communicate with students through email integration
- Manage course settings and permissions

### 🛠️ For Administrators
- Manage user accounts and course catalogs
- Monitor platform analytics and maintain quality standards
- Control access permissions to ensure security and privacy compliance

### ⚙️ Additional Features
- Secure authentication with role-based access controls
- Real-time notifications for updates and emergencies
- Group formation capabilities for enhanced collaboration
- Feedback collection for instructors and courses

---

## 🧩 APIs

The platform is powered by a comprehensive set of APIs:

### 🔐 Authentication
- `POST /register` — Register a user with specific access levels  
- `POST /login` — Verify credentials and grant access

### 📚 Course Management
- `POST /add_course` — Add new courses (Instructors/Admins only)  
- `PUT /update_course` — Update course details  
- `DELETE /delete_course` — Delete courses  
- `GET /fetch_course` — Retrieve details of a single course  
- `GET /fetch_courses` — Retrieve a list of all courses  
- `POST /enroll` — Enroll students into courses

### 🔔 Notifications
- `POST /notify` — Send real-time updates for events or deadlines

### 📝 Feedback and Reports
- `POST /feedback` — Submit feedback for instructors  
- `GET /generate_student_report` — Generate academic performance reports (Admin only)  
- `GET /generate_instructor_report` — Generate instructor rating reports

### 🔍 Utilities
- `GET /search` — Search for courses  
- `POST /bookmark` — Bookmark courses for quick reference  
- `POST /email` — Email integration for communication

---

Feel free to contribute or raise issues to improve GeniusFusion!

