;(a x) - square
(defun a(x) (* x x))

;(max x y) - maximum of two numbers
;(defun max(x y) (if (> x y) x y))

;(max x y z) - maximum of three numbers
(defun max3(x y z) (max x (max y z)))

;(! x) - factorial
(defun !(n) (if(= n 0) 1.0 (* n (!(- n 1)))))

;(sum n) - sum from 1 to n
(defun sum(n) (if(= n 0) 0 (+ n (sum (- n 1)))))

;(div k l) - return total and frictional patrts of k and l division
(defun div(k l) (truncate (/ k l)))

;(analyze n) - analyzing number on it's sign, checking (abs n) more than 1 and
;round it
(defun analyze(n) (list (if(< n 0) `- `+) (<= (abs n) 1) (round n)))
