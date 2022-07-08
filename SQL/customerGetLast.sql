SELECT    c.*, 
( SELECT group_concat(l.loaitiemnangContent SEPARATOR  '#') FROM loaitiemnang l WHERE l.customerId = c._id ) AS loaitiemnangContent,
( SELECT group_concat(t.theContent SEPARATOR  '#') FROM the t WHERE t.customerId = c._id  ) AS theContent,
( SELECT group_concat(h.historyContent SEPARATOR  '#') FROM history h WHERE h.customerId = c._id  ) AS historyContent
 FROM customer c
 WHERE c._id  = (SELECT c._id FROM customer c ORDER BY c._id DESC LIMIT 1)