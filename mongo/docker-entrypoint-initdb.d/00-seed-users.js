db.createCollection("users");

var bulk = db.users.initializeUnorderedBulkOp();

JSON.parse(cat("/seed/users.json")).forEach(user => bulk.insert(user));

bulk.execute();