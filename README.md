# Claims Importer

A data storage and processing backend for claims, which can now be queried, analyzed, and used in your applications.

# What I created
Database: A PostgreSQL database named pipeline.
- Table: A table called claims with this structure:
- id → Unique identifier (auto-incremented)
- provider → Name of the healthcare provider (text)
- claim_number → Unique identifier for the claim (text)
- status → Status of the claim (e.g., pending, paid) (text)
- claim_amount → Amount of the claim (numeric, 2 decimal places)
- claim_date → Date of the claim (date)

Imported Data: I loaded a CSV file (claims.csv) into the claims table using PostgreSQL’s COPY command.

# How it’s used
- Store claims data: This table now holds all your claim records for easy access.
- Querying & Analysis: You can run SQL queries to:
- See all claims: SELECT * FROM claims;
- Filter by provider: SELECT * FROM claims WHERE provider = 'Provider A';
- Summarize amounts: SELECT provider, SUM(claim_amount) FROM claims GROUP BY provider;

Backend API usage: My .NET application can connect to this database, read and manipulate claim data, and provide endpoints (like my /api/claims/ingest/csv) to interact with the data programmatically.

Data integrity: The table schema ensures that claim amounts are numeric, dates are stored correctly, and each claim has a unique ID.
