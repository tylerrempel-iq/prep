alias IQMetrix.ModelFactory

people = SeedData.generate_elements(1000, fn i -> ModelFactory.build(:person) end);
