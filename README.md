# BlogApp API

The project contains the following endpoints:
1.	AuthController
- 	POST /api/auth/signin
2.	BlogPostsController
- 	GET /api/blogposts
- 	GET /api/blogposts/user/{userId}
- 	POST /api/blogposts
3.	CommentsController
- 	GET /api/blogposts/{postId}/comments
- 	POST /api/blogposts/{postId}/comments

# Note- This uses SQL Server db 
- * (Use Update-Database command for firsttime use)
- (localdb)\\MSSQLLocalDB Database - BlogAppDb 

# Some useful commands
- ** Add-Migration InitialCreate -Project BlogApp.Core 
- ** Update-Database -Project BlogApp.Core 

- ** Install-Package FirebaseAdmin 
- ** Install-Package Google.Apis.Auth 
- ** Install-Package Microsoft.AspNetCore.Authentication.JwtBearer 

# Firebase API
For testing purpose a user added newazureacc1@gmail.com pwd1231

# API Documentation

## AuthController
### Sign In
- **Endpoint**: `POST /api/auth/signin`
- **Description**: Sign in with email and password.  Just ht it, I am internalary using correct valus, I will give AccessToken

## BlogPostsController

### Get All Blog Posts
- **Endpoint**: `GET /api/blogposts`
- **Description**: Get all blog posts.
- **Authorization**: Required

### Get User Blog Posts
- **Endpoint**: `GET /api/blogposts/user/{userId}`
- **Description**: Get blog posts by a specific user.
- **Authorization**: Required

### Create Blog Post
- **Endpoint**: `POST /api/blogposts`
- **Description**: Create a new blog post.
- **Authorization**: Required
- **Request Body**:

## CommentsController

### Get Comments
- **Endpoint**: `GET /api/blogposts/{postId}/comments`
- **Description**: Get comments for a specific blog post.
- **Authorization**: Required

### Create Comment
- **Endpoint**: `POST /api/blogposts/{postId}/comments`
- **Description**: Create a new comment for a specific blog post.
- **Authorization**: Required
- **Request Body**: