-- SEED

-- CATEGORIES
insert into Categories(id,Title,image) values('66895D5C-3935-462F-8062-2E8568F966C0','Veículos','teste0.jpg');
insert into Categories(id,Title,image) values('77365D24-55B7-4672-ADD4-49DCCAF0E09E','Instrumentos musicais','5d3c5b7a93218_gg.jpg')
insert into Categories(id,Title,image) values('2F10E062-E086-4718-9B9E-67A3BBD448F8','Ferramentas','8bb64aa0184f8d6138a262b5926db6ae.jpg');
insert into Categories(id,Title,image) values('048B8742-4CC6-4F7D-849C-83EBD77D6AE0','Suplementos','whey-protein.png');
insert into Categories(id,Title,image) values('6523648C-11A7-46B8-8154-85A4EBEA22BC','Livros','51d1qVhmAmL.jpg');
-- SUBCATEGORIES
insert into SubCategories(id, CategoryId, Title) values ('77365D24-55B7-4672-ADD4-49DCCAF00000', '77365D24-55B7-4672-ADD4-49DCCAF0E09E', 'Cordas');
insert into SubCategories(id, CategoryId, Title) values ('77365D24-55B7-4672-ADD4-49DCCAF00001', '77365D24-55B7-4672-ADD4-49DCCAF0E09E', 'Teclas');
insert into SubCategories(id, CategoryId, Title) values ('77365D24-55B7-4672-ADD4-49DCCAF00002', '77365D24-55B7-4672-ADD4-49DCCAF0E09E', 'Áudio e Tecnologias');


select * from SubCategories;
select * from Categories;
