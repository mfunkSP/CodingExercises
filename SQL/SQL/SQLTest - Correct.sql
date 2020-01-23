--
-- http://www.microsoft.com/sqlserver/2008/en/us/express.aspx
--
-- Fix all syntax and execution errors.  DO NOT change schema or data types.
--
-- Write the five queries listed at the bottom.
--
-- NOTE: Even if you are unable to fix the syntax and execution erros, please make your best attempt at the queries.
--

IF OBJECT_ID('Part') IS NOT NULL DROP TABLE Part
IF OBJECT_ID('Engine') IS NOT NULL DROP TABLE Engine
IF OBJECT_ID('Assembly') IS NOT NULL DROP TABLE Assembly

CREATE TABLE Part
(
	Part_ID int IDENTITY(1,1),
	[Name] varchar(20),
	Qty_on_hand tinyint,
	Cost decimal(5,2)
)

CREATE TABLE Engine
(
	Engine_ID int IDENTITY(1,1),
	[Name] varchar(20),
	Weight_lbs int,
)

CREATE TABLE Assembly
(
	Machine_id int,
	Part_id int
)

IF OBJECT_ID('add_part') IS NOT NULL DROP PROCEDURE add_part
GO
CREATE PROCEDURE add_part @name varchar(30), @cost decimal(5,2), @qty int = 1 
AS
--	INSERT INTO Part ([Name], Qty_on_hand, Cost) VALUES (@name, @cost, @qty)
	INSERT INTO Part ([Name], Cost, Qty_on_hand) VALUES (@name, @cost, @qty)
GO

IF OBJECT_ID('add_engine') IS NOT NULL DROP PROCEDURE add_engine
GO
CREATE PROCEDURE add_engine @name varchar(20), @weight int
AS
	INSERT INTO Engine ([Name], Weight_lbs) VALUES (@name, @weight)
GO

IF OBJECT_ID('assemble') IS NOT NULL DROP PROCEDURE assemble
GO
CREATE PROCEDURE assemble @engine_name varchar(20), @part_name varchar(30)
AS
	DECLARE @engine_id int
	SELECT @engine_id = Engine_ID FROM Engine WHERE [Name] = @engine_name

	DECLARE @part_id int
	SELECT @part_id = Part_ID FROM Part WHERE [Name] = @part_name

	INSERT INTO Assembly (Machine_id, Part_id) VALUES (@engine_id, @part_id)
GO

SET NOCOUNT ON
EXEC add_part 'Piston', 21.50, 4
EXEC add_part 'Connecting Rod', 5.50, 1
EXEC add_part 'Crankshaft', 121.50, 4
EXEC add_part 'Exhaust', 8.50, 4
EXEC add_part 'Intake', 32.50, 4
EXEC add_part 'Turbo Charger', 321.50, 1

EXEC add_engine 'Ford', 610
EXEC add_engine 'Chevy', 570
EXEC add_engine 'Mazda', 300

EXEC assemble 'Mazda', 'Crankshaft'
EXEC assemble 'Mazda', 'Connecting Rod'
EXEC assemble 'Mazda', 'Connecting Rod'
EXEC assemble 'Mazda', 'Piston'
EXEC assemble 'Mazda', 'Piston'
EXEC assemble 'Mazda', 'Exhaust'
EXEC assemble 'Mazda', 'Intake'

EXEC assemble 'Ford', 'Crankshaft'
EXEC assemble 'Ford', 'Connecting Rod'
EXEC assemble 'Ford', 'Connecting Rod'
EXEC assemble 'Ford', 'Connecting Rod'
EXEC assemble 'Ford', 'Connecting Rod'
EXEC assemble 'Ford', 'Piston'
EXEC assemble 'Ford', 'Piston'
EXEC assemble 'Ford', 'Piston'
EXEC assemble 'Ford', 'Piston'
EXEC assemble 'Ford', 'Exhaust'
EXEC assemble 'Ford', 'Intake'

EXEC assemble 'Chevy', 'Crankshaft'
EXEC assemble 'Chevy', 'Connecting Rod'
EXEC assemble 'Chevy', 'Connecting Rod'
EXEC assemble 'Chevy', 'Connecting Rod'
EXEC assemble 'Chevy', 'Connecting Rod'
EXEC assemble 'Chevy', 'Connecting Rod'
EXEC assemble 'Chevy', 'Connecting Rod'
EXEC assemble 'Chevy', 'Piston'
EXEC assemble 'Chevy', 'Piston'
EXEC assemble 'Chevy', 'Piston'
EXEC assemble 'Chevy', 'Piston'
EXEC assemble 'Chevy', 'Piston'
EXEC assemble 'Chevy', 'Piston'
EXEC assemble 'Chevy', 'Exhaust'
EXEC assemble 'Chevy', 'Intake'

-- Write a query to select all parts that cost more than $100
SELECT * FROM Part
WHERE Cost > 100;

-- Write a query to select all parts in order from most to least expensive
SELECT * FROM Part
ORDER BY Cost DESC;


-- Write a query to select all distinct part names used to make the engines
SELECT DISTINCT([Name]) FROM Part;


-- Write a query to select all unused parts
SELECT Part.[Name] FROM Part
LEFT JOIN Assembly
ON Part.Part_ID = Assembly.Part_id
WHERE Assembly.Part_id is null;


-- Write a query that lists each engine and its cost.
SELECT Engine.[Name], sum(Part.Cost)
FROM Engine
inner join assembly on assembly.Machine_id = Engine.Engine_ID
inner join Part on assembly.Part_id =  Part.Part_id
--where assembly.Engine_ID = assembly.Engine_ID
group by Engine.Name;
