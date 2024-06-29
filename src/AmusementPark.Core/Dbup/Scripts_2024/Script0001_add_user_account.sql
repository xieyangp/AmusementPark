create table if not exists `user_account`
(
    `id` int primary key auto_increment,
    `created_on` datetime not null,
    `modified_on` datetime not null,
    `user_name` varchar(512) not null,
    `pass_word` varchar(128) not null,
    `role` varchar(50) not null
)