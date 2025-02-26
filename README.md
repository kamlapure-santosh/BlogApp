# BlogApp API

API Endpoints

View all blog posts
Endpoint: GET /api/blogposts
Description: Retrieves a list of all blog posts.

View user's own blog posts
Endpoint: GET /api/blogposts/user/{userId}
Description: Retrieves a list of blog posts created by a specific user.

View comments on blog posts
Endpoint: GET /api/blogposts/{postId}/comments
Description: Retrieves a list of comments for a specific blog post.

Create a blog post
Endpoint: POST /api/blogposts
Description: Creates a new blog post.
Request Body: JSON object containing the blog post details (title, content, etc.).
Comment on blog posts

Endpoint: POST /api/blogposts/{postId}/comments
Description: Adds a comment to a specific blog post.
Request Body: JSON object containing the comment details (content, userId, etc.).

# this uses SQL Server db 
(localdb)\\MSSQLLocalDB Database - BlogAppDb

# Some usefull commands
Add-Migration InitialCreate -Project BlogApp.Core
Update-Database -Project BlogApp.Core

Install-Package FirebaseAdmin
Install-Package Google.Apis.Auth
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer

# Firebase API
user added newazureacc1@gmail.com pwd1231