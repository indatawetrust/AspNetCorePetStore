--
-- PostgreSQL database dump
--

-- Dumped from database version 10.6 (Ubuntu 10.6-0ubuntu0.18.04.1)
-- Dumped by pg_dump version 10.6 (Ubuntu 10.6-0ubuntu0.18.04.1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: Categorys; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Categorys" (
    "Id" bigint NOT NULL,
    "Name" text
);


--
-- Name: Categorys_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public."Categorys_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: Categorys_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public."Categorys_Id_seq" OWNED BY public."Categorys"."Id";


--
-- Name: Orders; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Orders" (
    "Id" bigint NOT NULL,
    "PetId" bigint,
    "Quantity" integer,
    "ShipDate" timestamp without time zone,
    "Status" integer,
    "Complete" boolean
);


--
-- Name: Orders_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public."Orders_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: Orders_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public."Orders_Id_seq" OWNED BY public."Orders"."Id";


--
-- Name: Pets; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Pets" (
    "Id" bigint NOT NULL,
    "CategoryId" bigint,
    "Name" text NOT NULL,
    "PhotoUrls" text[] NOT NULL,
    "Status" integer
);


--
-- Name: Pets_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public."Pets_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: Pets_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public."Pets_Id_seq" OWNED BY public."Pets"."Id";


--
-- Name: Tags; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Tags" (
    "Id" bigint NOT NULL,
    "Name" text,
    "PetId" bigint
);


--
-- Name: Tags_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public."Tags_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: Tags_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public."Tags_Id_seq" OWNED BY public."Tags"."Id";


--
-- Name: Users; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Users" (
    "Id" bigint NOT NULL,
    "Username" text,
    "FirstName" text,
    "LastName" text,
    "Email" text,
    "Password" text,
    "Phone" text,
    "UserStatus" integer
);


--
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public."Users_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- Name: Categorys Id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Categorys" ALTER COLUMN "Id" SET DEFAULT nextval('public."Categorys_Id_seq"'::regclass);


--
-- Name: Orders Id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Orders" ALTER COLUMN "Id" SET DEFAULT nextval('public."Orders_Id_seq"'::regclass);


--
-- Name: Pets Id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Pets" ALTER COLUMN "Id" SET DEFAULT nextval('public."Pets_Id_seq"'::regclass);


--
-- Name: Tags Id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Tags" ALTER COLUMN "Id" SET DEFAULT nextval('public."Tags_Id_seq"'::regclass);


--
-- Name: Users Id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);


--
-- Name: Categorys PK_Categorys; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Categorys"
    ADD CONSTRAINT "PK_Categorys" PRIMARY KEY ("Id");


--
-- Name: Orders PK_Orders; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_Orders" PRIMARY KEY ("Id");


--
-- Name: Pets PK_Pets; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Pets"
    ADD CONSTRAINT "PK_Pets" PRIMARY KEY ("Id");


--
-- Name: Tags PK_Tags; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Tags"
    ADD CONSTRAINT "PK_Tags" PRIMARY KEY ("Id");


--
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Pets_CategoryId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Pets_CategoryId" ON public."Pets" USING btree ("CategoryId");


--
-- Name: IX_Tags_PetId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Tags_PetId" ON public."Tags" USING btree ("PetId");


--
-- Name: Pets FK_Pets_Categorys_CategoryId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Pets"
    ADD CONSTRAINT "FK_Pets_Categorys_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."Categorys"("Id") ON DELETE RESTRICT;


--
-- Name: Tags FK_Tags_Pets_PetId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Tags"
    ADD CONSTRAINT "FK_Tags_Pets_PetId" FOREIGN KEY ("PetId") REFERENCES public."Pets"("Id") ON DELETE RESTRICT;


--
-- PostgreSQL database dump complete
--

