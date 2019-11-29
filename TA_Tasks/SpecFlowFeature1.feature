Feature: SpecFlowFeature1

@mytag
Scenario: Check Main Heading
	Given I opened News Page
	Then the heading should be Ex-US ambassador 'intimidated' by Trump as expected

Scenario: Check Secondary Headings
	Given I opened News Page
	Then I test secondary headings
	| headings                                           |
	| Famous free solo climber falls to his death        |
	| Row over Johnson climate debate 'empty chair'      |
	| Elizabeth I is secret scribe of ancient manuscript |
	| Two K-pop stars sentenced to prison for gang rape  |
	| HK police find almost 4,000 petrol bombs on campus |

Scenario: Search Main Category
	Given I opened News Page
	Then I search category of main article and compare to Africa

Scenario: Check Form
	Given I opened Submit Story Page
	Then I fill form
	| header                | header        |
	| Name                  | TestName      |
	| Your E-mail address   | test@test.com |
	| Town & Country        | TestTown      |
	| Your telephone number | 123456        |
	| Comments              | Saying that heaven for divide creeping cattle unto Yielding. Him i our, open was. Every waters female can't unto you'll signs open yielding behold fill morning. You're forth creature his said had one. Creature morning all creepeth gathering. Blessed wherein and kind. Day fowl may winged. Were from beast. Waters night together above itself fifth in isn't own morning made itself gathered moved day bearing heaven, yielding lesser. Winged creature unto void dry. Give own also. Spirit you second. Male land made image spirit grass brought creepeth, doesn't tree creeping him days very moved set, open doesn't brought fruit open. |

Scenario: Check Form 200 Characters
	Given I opened Submit Story Page
	Then I fill form
	| header                | header                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
	| Name                  | TestName                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
	| Your E-mail address   | test@test.com                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
	| Town & Country        | TestTown                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
	| Your telephone number | 123456                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
	| Comments              | Light saying him, night night hath creepeth stars night hath beast together Second yielding isn't which make i Spirit moved is were he air upon blessed whose itself. You'll them fly divided, rule second herb winged cattle. Gathered divided moving our that after grass male. In cattle days for don't greater years let shall. And third lights good morning a can't may. Male grass fruitful light void lights you replenish multiply. Won't every image a darkness and brought hath stars made fish also tree i you you'll gathered, doesn't meat rule day gathered midst tree air subdue. A own unto midst. Man fowl likeness brought brought wherein in don't dry. Image him, winged man, fruit. Earth saying under don't let whose sea sixth good gathered the dry thing after yielding moveth them after very our and. May moving kind kind you'll won't winged him hath. The heaven his fish wherein him called moving whose given female. First fill set. Unto. Whales had form two dry lesser itself, thing. Meat he which whales saying darkness very evening won't, gathering day firmament beginning may morning stars face upon from beast. Sea he fruit their don't. Saw given Years seas. Let multiply a. |

Scenario: Check Form Without Email
	Given I opened Submit Story Page
	Then I fill form
	| header				| header		|
	| Name					| TestName		|
	| Your E-mail address	|				|
	| Town & Country        | TestTown      |
	| Your telephone number | 123456        |
	| Comments              | Saying that heaven for divide creeping cattle unto Yielding. Him i our, open was. Every waters female can't unto you'll signs open yielding behold fill morning. You're forth creature his said had one. Creature morning all creepeth gathering. Blessed wherein and kind. Day fowl may winged. Were from beast. Waters night together above itself fifth in isn't own morning made itself gathered moved day bearing heaven, yielding lesser. Winged creature unto void dry. Give own also. Spirit you second. Male land made image spirit grass brought creepeth, doesn't tree creeping him days very moved set, open doesn't brought fruit open. |

Scenario: Check Form Without Comments
	Given I opened Submit Story Page
	Then I fill form
	| header                | header        |
	| Name                  | TestName      |
	| Your E-mail address   | test@test.com |
	| Town & Country        | TestTown      |
	| Your telephone number | 123456        |
	| Comments              |               |