--
-- PostgreSQL database cluster dump
--

-- Started on 2024-05-24 13:28:16

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Drop databases (except postgres and template1)
--





--
-- Drop roles
--

DROP ROLE IF EXISTS postgres;


--
-- Roles
--

CREATE ROLE postgres;
ALTER ROLE postgres WITH SUPERUSER INHERIT CREATEROLE CREATEDB LOGIN REPLICATION BYPASSRLS PASSWORD 'SCRAM-SHA-256$4096:Yf1Mb1gXxwLTNMFwtyJgUQ==$HDKZR6SEtVvLh+ctiCWwUkxSC3ZnRYz2fGGbB60qVd0=:SyGB1XoXmQJkHxds2e4/ckA7I1KdtpTSN3LgEeW82pI=';

--
-- User Configurations
--








--
-- Databases
--

--
-- Database "template1" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.0

-- Started on 2024-05-24 13:28:16

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

UPDATE pg_catalog.pg_database SET datistemplate = false WHERE datname = 'template1';
DROP DATABASE template1;
--
-- TOC entry 4831 (class 1262 OID 1)
-- Name: template1; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE template1 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Latin America.1252';


ALTER DATABASE template1 OWNER TO postgres;

\connect template1

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
-- TOC entry 4832 (class 0 OID 0)
-- Dependencies: 4831
-- Name: DATABASE template1; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE template1 IS 'default template for new databases';


--
-- TOC entry 4834 (class 0 OID 0)
-- Name: template1; Type: DATABASE PROPERTIES; Schema: -; Owner: postgres
--

ALTER DATABASE template1 IS_TEMPLATE = true;


\connect template1

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
-- TOC entry 4833 (class 0 OID 0)
-- Dependencies: 4831
-- Name: DATABASE template1; Type: ACL; Schema: -; Owner: postgres
--

REVOKE CONNECT,TEMPORARY ON DATABASE template1 FROM PUBLIC;
GRANT CONNECT ON DATABASE template1 TO PUBLIC;


-- Completed on 2024-05-24 13:28:17

--
-- PostgreSQL database dump complete
--

--
-- Database "postgres" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.0

-- Started on 2024-05-24 13:28:17

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

DROP DATABASE postgres;
--
-- TOC entry 4925 (class 1262 OID 5)
-- Name: postgres; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Latin America.1252';


ALTER DATABASE postgres OWNER TO postgres;

\connect postgres

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
-- TOC entry 4926 (class 0 OID 0)
-- Dependencies: 4925
-- Name: DATABASE postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- TOC entry 2 (class 3079 OID 16384)
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- TOC entry 4927 (class 0 OID 0)
-- Dependencies: 2
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 221 (class 1259 OID 16426)
-- Name: proveedor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.proveedor (
    id integer NOT NULL,
    fecha_creacion timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    rif character varying(10) NOT NULL,
    nombre character varying(50) NOT NULL,
    telefono character varying(15),
    email character varying(20) NOT NULL,
    direccion character varying(100),
    dias_credito integer DEFAULT 0 NOT NULL,
    dias_promedio_entrega numeric DEFAULT 1
);


ALTER TABLE public.proveedor OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16425)
-- Name: Proveedor_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.proveedor ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Proveedor_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 225 (class 1259 OID 16477)
-- Name: catalogo_proveedor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.catalogo_proveedor (
    id integer NOT NULL,
    id_proveedor integer NOT NULL,
    articulo_proveedor character varying(40) NOT NULL,
    codigo_barra character varying(15) NOT NULL,
    costo numeric DEFAULT 0.1 NOT NULL,
    fecha_creacion timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


ALTER TABLE public.catalogo_proveedor OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16476)
-- Name: catalogo_proveedor_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.catalogo_proveedor ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.catalogo_proveedor_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 233 (class 1259 OID 16632)
-- Name: cliente; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cliente (
    id integer NOT NULL,
    nombre character varying NOT NULL,
    numero_identidad integer NOT NULL,
    fecha_creacion timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    telefono character varying
);


ALTER TABLE public.cliente OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 16631)
-- Name: cliente_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.cliente ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.cliente_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 227 (class 1259 OID 16590)
-- Name: factura; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.factura (
    id integer NOT NULL,
    fecha_factura timestamp without time zone NOT NULL,
    id_proveedor integer NOT NULL,
    numero_factura integer NOT NULL,
    numero_control integer NOT NULL,
    subtotal numeric DEFAULT 0 NOT NULL,
    total_impuesto numeric DEFAULT 0 NOT NULL,
    total_descuento numeric DEFAULT 0 NOT NULL,
    total_neto numeric DEFAULT 0 NOT NULL,
    fecha_creacion timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.factura OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16589)
-- Name: factura_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.factura ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.factura_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 223 (class 1259 OID 16469)
-- Name: inventario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.inventario (
    id integer NOT NULL,
    fecha_creacion timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    existencia integer DEFAULT 0 NOT NULL,
    proveedor_id integer NOT NULL,
    costo numeric NOT NULL,
    precio numeric NOT NULL,
    codigo_articulo character varying NOT NULL,
    "descripción_articulo" character varying NOT NULL,
    codigo_barra character varying NOT NULL
);


ALTER TABLE public.inventario OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16468)
-- Name: inventario_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.inventario ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.inventario_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 16409)
-- Name: role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.role (
    id integer NOT NULL,
    rol character varying NOT NULL,
    descripcion character varying NOT NULL
);


ALTER TABLE public.role OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16408)
-- Name: role_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.role ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.role_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 229 (class 1259 OID 16608)
-- Name: system_uuid_key; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.system_uuid_key (
    id integer NOT NULL,
    uuid uuid DEFAULT gen_random_uuid() NOT NULL,
    creation_date time without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    expiration_date time without time zone DEFAULT (CURRENT_TIMESTAMP + '2 days'::interval day)
);


ALTER TABLE public.system_uuid_key OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16607)
-- Name: system_uuid_key_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.system_uuid_key ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.system_uuid_key_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 217 (class 1259 OID 16399)
-- Name: usuario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.usuario (
    id integer NOT NULL,
    login character varying NOT NULL,
    email character varying NOT NULL,
    nombre_completo character varying NOT NULL,
    "contraseña" character varying NOT NULL,
    fecha_creacion time without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    role_id integer DEFAULT 1 NOT NULL,
    estado integer DEFAULT 1 NOT NULL
);


ALTER TABLE public.usuario OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16398)
-- Name: usuario_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.usuario ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.usuario_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 231 (class 1259 OID 16622)
-- Name: venta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.venta (
    id integer NOT NULL,
    numero_factura integer NOT NULL,
    fecha_factura time without time zone NOT NULL,
    porcentaje_iva numeric NOT NULL,
    monto_base numeric NOT NULL,
    monto_iva numeric DEFAULT 0 NOT NULL,
    numero_control integer NOT NULL,
    cliente_id integer NOT NULL,
    fecha_creacion time without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


ALTER TABLE public.venta OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 16621)
-- Name: venta_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.venta ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.venta_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 4759 (class 2606 OID 16432)
-- Name: proveedor Proveedor_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.proveedor
    ADD CONSTRAINT "Proveedor_pkey" PRIMARY KEY (id);


--
-- TOC entry 4761 (class 2606 OID 16485)
-- Name: catalogo_proveedor catalogo_proveedor_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.catalogo_proveedor
    ADD CONSTRAINT catalogo_proveedor_pkey PRIMARY KEY (id);


--
-- TOC entry 4771 (class 2606 OID 16639)
-- Name: cliente cliente_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT cliente_pkey PRIMARY KEY (id);


--
-- TOC entry 4763 (class 2606 OID 16487)
-- Name: catalogo_proveedor cod_barra_x_proveedor_UNIQUE; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.catalogo_proveedor
    ADD CONSTRAINT "cod_barra_x_proveedor_UNIQUE" UNIQUE (id_proveedor, codigo_barra);


--
-- TOC entry 4751 (class 2606 OID 16417)
-- Name: usuario email_unique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT email_unique UNIQUE (email);


--
-- TOC entry 4765 (class 2606 OID 16601)
-- Name: factura factura_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_pkey PRIMARY KEY (id_proveedor);


--
-- TOC entry 4753 (class 2606 OID 16419)
-- Name: usuario login_unique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT login_unique UNIQUE (login);


--
-- TOC entry 4757 (class 2606 OID 16415)
-- Name: role role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (id);


--
-- TOC entry 4767 (class 2606 OID 16615)
-- Name: system_uuid_key system_uuid_key_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.system_uuid_key
    ADD CONSTRAINT system_uuid_key_pkey PRIMARY KEY (id);


--
-- TOC entry 4755 (class 2606 OID 16407)
-- Name: usuario usuario_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (id);


--
-- TOC entry 4769 (class 2606 OID 16630)
-- Name: venta venta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.venta
    ADD CONSTRAINT venta_pkey PRIMARY KEY (id);


--
-- TOC entry 4776 (class 2606 OID 16641)
-- Name: venta cliente_id_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.venta
    ADD CONSTRAINT "cliente_id_FK" FOREIGN KEY (id) REFERENCES public.cliente(id);


--
-- TOC entry 4773 (class 2606 OID 16616)
-- Name: inventario proveedor_id_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventario
    ADD CONSTRAINT "proveedor_id_FK" FOREIGN KEY (proveedor_id) REFERENCES public.proveedor(id);


--
-- TOC entry 4774 (class 2606 OID 16488)
-- Name: catalogo_proveedor provider_id_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.catalogo_proveedor
    ADD CONSTRAINT "provider_id_FK" FOREIGN KEY (id_proveedor) REFERENCES public.proveedor(id);


--
-- TOC entry 4775 (class 2606 OID 16602)
-- Name: factura provider_id_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.factura
    ADD CONSTRAINT "provider_id_FK" FOREIGN KEY (id_proveedor) REFERENCES public.proveedor(id) ON DELETE RESTRICT;


--
-- TOC entry 4772 (class 2606 OID 16420)
-- Name: usuario role_id_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT "role_id_FK" FOREIGN KEY (role_id) REFERENCES public.role(id);


-- Completed on 2024-05-24 13:28:17

--
-- PostgreSQL database dump complete
--

-- Completed on 2024-05-24 13:28:17

--
-- PostgreSQL database cluster dump complete
--

