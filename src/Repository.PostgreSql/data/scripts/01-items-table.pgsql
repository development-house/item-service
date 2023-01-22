-- This script was generated by the ERD tool in pgAdmin 4.
-- Please log an issue at https://redmine.postgresql.org/projects/pgadmin4/issues/new if you find any bugs, including reproduction steps.
BEGIN;


CREATE TABLE IF NOT EXISTS public.items
(
    serial serial,
    "id" uuid NOT NULL,
    "name" character varying(255) NOT NULL,
    "label" character varying(255) NOT NULL,
    "type" character varying(255) NOT NULL,
    category character varying(255) NOT NULL,
    model integer NOT NULL,
    texture integer NOT NULL,
    x integer NOT NULL,
    y integer NOT NULL,
    weight integer NOT NULL,
    decayrate integer NOT NULL,
    image character varying(255),
    deg character varying(255),
    "fullyDegrades" boolean NOT NULL,
    "nonStack" boolean NOT NULL,
    useable boolean NOT NULL,
    "unique" boolean NOT NULL,
    "shouldClose" boolean NOT NULL,
    "useRemove" boolean NOT NULL,
    description text NOT NULL DEFAULT '',
    PRIMARY KEY (id)
);
END;