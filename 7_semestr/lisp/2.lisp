;return A in this list
;`((1 2) (A (3 4)))
(defun takeA() (car (car (cdr `((1 2) (A (3 4)))))))

;return list (A B (C D)) from s-expressions (A B), C and D
(defun makeList() (append `(A B) (list (list `C `D))))

(defun analyzeList(L) (if (AND (numberp (nth 0 L))
                               (numberp (nth 2 L))
                               (numberp (nth 4 L)))
                        (+ (nth 0 L) (nth 2 L) (nth 4 L))
                        (list (nth 0 L) (nth 2 L) (nth 4 L))))
