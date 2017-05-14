SELECT company.company_code,company.founder,
	   COUNT(DISTINCT lead_manager.lead_manager_code),
	   COUNT(DISTINCT senior_manager.senior_manager_code),
	   COUNT(DISTINCT manager.manager_code),
	   COUNT(DISTINCT employee.employee_code)
FROM Company company 
	 JOIN Lead_Manager lead_manager ON company.company_code=lead_manager.company_code
	 JOIN Senior_Manager senior_manager ON company.company_code=senior_manager.company_code
	 JOIN Manager manager ON manager.company_code=company.company_code
	 JOIN Employee employee ON employee.company_code=company.company_code
GROUP BY company.company_code,company.founder
ORDER BY company.company_code;