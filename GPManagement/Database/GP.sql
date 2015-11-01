create database if not exists GP;
use GP;
create table if not exists GP_Schedule(
	s_id int(11) not null auto_increment,
    s_time datetime not null,
    s_type varchar(5) not null,
    s_place varchar(100) not null,
    s_content text not null,
    s_comment text,
    constraint pk_sche primary key(s_id),
    constraint ck_type check(s_type='Spend' or s_type='Add')
);

create table if not exists GP_Budget(
	b_id int(11) not null auto_increment,
    b_time datetime not null,
    b_type varchar(5) not null,
    b_quantity double not null,
    b_total double not null,
    b_comment text not null,
    constraint pk_bud primary key(b_id),
    constraint ck_type check(b_type='Metting' or b_type='Other')
);

create table if not exists GP_Project(
	p_id int(11) not null auto_increment,
    p_name varchar(50) not null,
    p_start_date datetime not null,
    p_end_date datetime not null,
    constraint pk_proj primary key(p_id),
    constraint unq_p_name unique(p_name)
    
);

create table if not exists GP_Employee(
	e_id int(11) not null auto_increment,
    e_name varchar(50) not null,
    e_phone varchar(11) not null,
    e_email varchar(50) not null,
    e_birth_day datetime not null,
    e_image blob,
    constraint pk_emp primary key(e_id),
    constraint unq_phone_mail unique(e_phone,e_email)
);

create table if not exists GP_Task(
	t_id int(11) not null auto_increment,
    t_proj_id int(11) not null,
    t_name varchar(50) not null,
    t_start_time datetime not null,
    t_end_time datetime not null,
    t_comment text,
    constraint pk_task primary key(t_id),
    constraint fk_proj_task foreign key(t_proj_id) references GP_Project(p_id),
    constraint unq_name unique(t_name)
);

create table if not exists GP_Task_Emp(
	te_id int(11) not null auto_increment,
    te_id_emp int(11) not null,
    te_id_task int(11) not null,
    te_comment text,
    constraint pk_te primary key(te_id),
    constraint fk_emp foreign key(te_id_emp) references GP_Employee(e_id),
    constraint fk_task foreign key(te_id_task) references GP_Task(t_id)
);