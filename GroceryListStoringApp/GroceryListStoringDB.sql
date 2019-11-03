--
-- PostgreSQL database dump
--

-- Dumped from database version 10.10
-- Dumped by pg_dump version 10.10

-- Started on 2019-11-04 01:30:35

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12924)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2838 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 201 (class 1259 OID 16672)
-- Name: Grocery_Item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Grocery_Item" (
    id_grocery_item integer NOT NULL,
    item_description text NOT NULL
);


ALTER TABLE public."Grocery_Item" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16659)
-- Name: Grocery_List; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Grocery_List" (
    id_grocery_list integer NOT NULL,
    id_user_fk integer NOT NULL,
    permissions text NOT NULL
);


ALTER TABLE public."Grocery_List" OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 16682)
-- Name: Grocery_Store; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Grocery_Store" (
    id_grocery_list_fk integer NOT NULL,
    id_grocery_item_fk integer NOT NULL
);


ALTER TABLE public."Grocery_Store" OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 16648)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    id_user integer NOT NULL,
    username text NOT NULL,
    password text NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 16670)
-- Name: grocery_item_id_grocery_item_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.grocery_item_id_grocery_item_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.grocery_item_id_grocery_item_seq OWNER TO postgres;

--
-- TOC entry 2839 (class 0 OID 0)
-- Dependencies: 200
-- Name: grocery_item_id_grocery_item_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.grocery_item_id_grocery_item_seq OWNED BY public."Grocery_Item".id_grocery_item;


--
-- TOC entry 198 (class 1259 OID 16657)
-- Name: grocery_list_id_grocery_list_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.grocery_list_id_grocery_list_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.grocery_list_id_grocery_list_seq OWNER TO postgres;

--
-- TOC entry 2840 (class 0 OID 0)
-- Dependencies: 198
-- Name: grocery_list_id_grocery_list_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.grocery_list_id_grocery_list_seq OWNED BY public."Grocery_List".id_grocery_list;


--
-- TOC entry 196 (class 1259 OID 16646)
-- Name: users_id_user_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_user_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_user_seq OWNER TO postgres;

--
-- TOC entry 2841 (class 0 OID 0)
-- Dependencies: 196
-- Name: users_id_user_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_user_seq OWNED BY public."Users".id_user;


--
-- TOC entry 2691 (class 2604 OID 16675)
-- Name: Grocery_Item id_grocery_item; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_Item" ALTER COLUMN id_grocery_item SET DEFAULT nextval('public.grocery_item_id_grocery_item_seq'::regclass);


--
-- TOC entry 2690 (class 2604 OID 16662)
-- Name: Grocery_List id_grocery_list; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_List" ALTER COLUMN id_grocery_list SET DEFAULT nextval('public.grocery_list_id_grocery_list_seq'::regclass);


--
-- TOC entry 2689 (class 2604 OID 16651)
-- Name: Users id_user; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN id_user SET DEFAULT nextval('public.users_id_user_seq'::regclass);


--
-- TOC entry 2829 (class 0 OID 16672)
-- Dependencies: 201
-- Data for Name: Grocery_Item; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Grocery_Item" (id_grocery_item, item_description) FROM stdin;
1	cucumber
2	tomato
3	Nutela
4	water
7	Pringles
\.


--
-- TOC entry 2827 (class 0 OID 16659)
-- Dependencies: 199
-- Data for Name: Grocery_List; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Grocery_List" (id_grocery_list, id_user_fk, permissions) FROM stdin;
3	1	shared
1	1	public
2	1	private
5	1	private
6	2	private
7	2	private
\.


--
-- TOC entry 2830 (class 0 OID 16682)
-- Dependencies: 202
-- Data for Name: Grocery_Store; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Grocery_Store" (id_grocery_list_fk, id_grocery_item_fk) FROM stdin;
1	1
1	2
3	3
3	2
2	2
5	3
5	1
5	4
5	2
2	1
6	3
6	7
6	2
7	1
7	3
7	4
\.


--
-- TOC entry 2825 (class 0 OID 16648)
-- Dependencies: 197
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" (id_user, username, password) FROM stdin;
1	test_user1	1234
2	test_user2	1234
3	test_user3	1234
4	test_user4	1234
\.


--
-- TOC entry 2842 (class 0 OID 0)
-- Dependencies: 200
-- Name: grocery_item_id_grocery_item_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.grocery_item_id_grocery_item_seq', 7, true);


--
-- TOC entry 2843 (class 0 OID 0)
-- Dependencies: 198
-- Name: grocery_list_id_grocery_list_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.grocery_list_id_grocery_list_seq', 7, true);


--
-- TOC entry 2844 (class 0 OID 0)
-- Dependencies: 196
-- Name: users_id_user_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_user_seq', 4, true);


--
-- TOC entry 2697 (class 2606 OID 16680)
-- Name: Grocery_Item grocery_item_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_Item"
    ADD CONSTRAINT grocery_item_pkey PRIMARY KEY (id_grocery_item);


--
-- TOC entry 2695 (class 2606 OID 16664)
-- Name: Grocery_List grocery_list_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_List"
    ADD CONSTRAINT grocery_list_pkey PRIMARY KEY (id_grocery_list);


--
-- TOC entry 2699 (class 2606 OID 16686)
-- Name: Grocery_Store grocery_store_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_Store"
    ADD CONSTRAINT grocery_store_pkey PRIMARY KEY (id_grocery_list_fk, id_grocery_item_fk);


--
-- TOC entry 2693 (class 2606 OID 16656)
-- Name: Users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT users_pkey PRIMARY KEY (id_user);


--
-- TOC entry 2700 (class 2606 OID 16665)
-- Name: Grocery_List grocery_list_id_user_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_List"
    ADD CONSTRAINT grocery_list_id_user_fk_fkey FOREIGN KEY (id_user_fk) REFERENCES public."Users"(id_user);


--
-- TOC entry 2702 (class 2606 OID 16692)
-- Name: Grocery_Store grocery_store_id_grocery_item_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_Store"
    ADD CONSTRAINT grocery_store_id_grocery_item_fk_fkey FOREIGN KEY (id_grocery_item_fk) REFERENCES public."Grocery_Item"(id_grocery_item);


--
-- TOC entry 2701 (class 2606 OID 16687)
-- Name: Grocery_Store grocery_store_id_grocery_list_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grocery_Store"
    ADD CONSTRAINT grocery_store_id_grocery_list_fk_fkey FOREIGN KEY (id_grocery_list_fk) REFERENCES public."Grocery_List"(id_grocery_list);


-- Completed on 2019-11-04 01:30:35

--
-- PostgreSQL database dump complete
--

