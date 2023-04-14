-- Capture your answer here for each "Test It With SQL" section of this assignment
    -- write each as comments


--Part 1: List the columns and their data types in the Jobs table. 
-- Jobs Table: 
-- integer Id
-- varchar Name
-- integer EmployerId

--Part 2: Write a query to list the names of the employers in St. Louis City.
-- SELECT name
-- FROM employers
-- WHERE location = "St. Louis City";


--Part 3: Write a query to return a list of the names and descriptions of all skills that are attached to jobs in alphabetical order.
    --If a skill does not have a job listed, it should not be included in the results of this query.
-- SELECT skills.skillname, jobs.name
-- FROM skills
-- LEFT JOIN jobskills ON skills.id = jobskills.skillsid INNER JOIN jobs on jobskills.jobsid = jobs.id 
-- WHERE jobskills.jobsid is not null
-- ORDER BY skillname;