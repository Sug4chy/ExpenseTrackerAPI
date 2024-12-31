CREATE TABLE IF NOT EXISTS "user"
(
    id            UUID PRIMARY KEY,
    username      TEXT NOT NULL UNIQUE,
    password_hash TEXT NOT NULL
);