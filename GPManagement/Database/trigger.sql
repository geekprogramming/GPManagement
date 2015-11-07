use gp;

DELIMITER $$
CREATE TRIGGER `budget_before_insert` BEFORE INSERT ON `GP_Budget`
FOR EACH ROW
BEGIN
    IF NEW.b_type != 'Spend' or NEW.b_type != 'Add' THEN
        SIGNAL SQLSTATE '12345'
            SET MESSAGE_TEXT = 'check constraint on Budget type failed';
    END IF;
END$$   
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `schedule_before_insert` BEFORE INSERT ON `GP_Schedule`
FOR EACH ROW
BEGIN
    IF NEW.s_type != 'Meeting' or NEW.s_type != 'Other' THEN
        SIGNAL SQLSTATE '12345'
            SET MESSAGE_TEXT = 'check constraint on Schedule type failed';
    END IF;
END$$   
DELIMITER ;

