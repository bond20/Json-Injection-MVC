# Assessment

This project is part of the NetConstruct junior developer assessment.
It is a blog website built with ASP.NET MVC 5 and JSON-based content loading.

## Status

Complete.

## What was done

- Loaded blog post data from `App_Data/Blog-Posts.json`
- Wired `BlogController` to show the latest post by default
- Replaced the static page with a strongly typed Razor view
- Rendered the post title, date, image, HTML content, and comments from JSON
- Updated the styling so the page works cleanly with Bootstrap
- Verified the solution builds and runs locally

## Notes

- The project uses ASP.NET MVC 5, not ASP.NET Core MVC
- The blog content is data-driven from the JSON file in the repo
