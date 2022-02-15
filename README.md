# Account Management Backend - Level 3

Your task is to build a backend service that implements the [Account Management API](api-specification.yml). This API defines a set of operations for creating and reading account transactions. You can use [editor.swagger.io](https://editor.swagger.io/) to visualize the spec.

We added the necessary boilerplate configured with .NET 5.0. It includes:
1. A backend service with a `/ping` endpoint.
2. The necessary setup for running the API tests remotely.

### What we expect from you ⏳

- **Commit your code to a new branch called `implementation`**.
- **Make the provided API tests pass**. We added a set of API tests that run every time you push to a remote branch other than `master`/`main`. See the instructions below covering how to run them locally. 
- **Use an SQLite database as the service datastore.** We want to see how you design the database schema and SQL queries for working with the service data. Please use [SQLite](https://www.sqlite.org/index.html) as a DB engine.
- **Optimize the GET endpoints for speed.** When designing your service, ensure that the GET endpoints remain fast with the database growing in size.
- **Ensure no lost updates.** When submitting a new transaction, make sure no account balance updates are lost. E.g., when having two concurrent requests updating the same account balance.
- **Minimize the number of SQL queries for fetching max transaction volume.** Try to do it with ideally a single SQL query.
- **Organize your code as a set of low-coupled modules**. Avoid duplication and extract re-usable modules where it makes sense, but don't break things apart needlessly. We want to see that you can create a codebase that is easy to maintain.
- **Document your decisions.** Extend this README.md with info about how to run your application along with any hints that will help us review your submission and better understand the decisions you made.

### Running the API tests locally ⚙️

* Run`npm install`.
* Build the app with `npm run build`.
* Run the app with `npm run start`.
* Run the tests with `npm run test`.

We use [Cypress](https://www.cypress.io/) for API tests. For the sake of this exercise, treat it as a simple HTTP request runner.

### When you're done ✅

1. Ensure that the API tests pass remotely (see the build status on GitHub under the Actions tab).
2. Create a Pull Request from the `implementation` branch.
3. Answer the questions you get on your Pull Request.

**If you don't have enough time to finish**, push what you got and describe how you'd do the rest in a `.md` file.

### Need help? 🤯

Start with [Troubleshooting](https://www.notion.so/Troubleshooting-d18bdb5d2ac341bb82b21f0ba8fb9546), and in case it didn't help, create a new GitHub issue. A human will help you. 

### Time estimate ⏳

About **3 hours**.

---

Made by [DevSkills](https://devskills.co). 

How was your experience? **Give us a shout on [Twitter](https://twitter.com/DevSkillsHQ) / [LinkedIn](https://www.linkedin.com/company/devskills)**.
