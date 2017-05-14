INSERT INTO Company (company_code,founder) VALUES 
('C1','Monika'),
('C2','Samantha');

INSERT INTO Lead_Manager (lead_manager_code,company_code) VALUES
('LM1','C1'),
('LM2','C2');

INSERT INTO Senior_Manager (senior_manager_code,lead_manager_code,company_code) VALUES
('SM1','LM1','C1'),
('SM2','LM1','C1'),
('SM3','LM2','C2');

INSERT INTO Manager (manager_code,senior_manager_code,lead_manager_code,company_code) VALUES
('M1','SM1','LM1','C1'),
('M2','SM3','LM2','C2'),
('M3','SM3','LM2','C2');

INSERT INTO Employee (employee_code,manager_code,senior_manager_code,lead_manager_code,company_code) VALUES
('E1','M1','SM1','LM1','C1'),
('E2','M1','SM1','LM1','C1'),
('E3','M2','SM3','LM2','C2'),
('E4','M3','SM3','LM2','C2');