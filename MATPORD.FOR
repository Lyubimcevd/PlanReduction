      INTEGER*2 A(26,200),S(2,200),P(2,200),TQ(6,500),TQC(4,500),NXZ(10,TPOR0004
     *4),ZAK(4,500),C,U(20,100)                                         TPOR0005
      INTEGER QZ(4,500),IW(100),UW(2,200)                               TPOR0006
      INTEGER*2 KOP(300)                                                TPOR0007
      DATA C/'99'/                                                      TPOR0008
 21   FORMAT(1X,'IW:')                                                  TPOR0009
 22   FORMAT(1X,12(I9,1X))                                              TPOR0010
      OPEN(2,FILE='f:\ASYIP\U.DAT',FORM='UNFORMATTED')                  TPOR0011
      open(9,file='prn')
      READ(2) NW,NU                                                     TPOR0012
      READ(2) ((UW(I,J),I=1,2),J=1,NW),((U(I,J),I=1,20),J=1,NU)
1     FORMAT(40A2)                                                      TPOR0013
10    FORMAT('0A: NN  PTM   ND   **MATEPИAЛ**   **PAЗMEPЫ***  NMK   NSS TPOR0014
     * QS   NSM  QO   NSP  QP    P     HAИMEHOBAHИE ДETAЛИ')
101   FORMAT(1H ,17I5,5X
     *,10A2)                                                            TPOR0016
11    FORMAT(1H0,'S:  NN     NSA    QD',30X,'P:  N     NSA    QP')
111   FORMAT(1H ,I
     *6,2I7,30X,I6,2I7)                                                 TPOR0018
 12   FORMAT('Q NN  TQ:    NSU   ШOБ  SDS    DN    DK   DNS  QZ:    TP  TPOR0019
     *   PAC     QOП   QO     TQC:     DWO     Q     TAБ       WI')
121   FORMAT(1H ,
     *I3,I11,5I6,I12,I9,I7,I10,I13,3I7)                                 TPOR0021
      WRITE(*,'('' задай номера заказов  '')')
      READ(*,1) ((ZAK(I,J),I=1,4),J=1,10)                               TPOR0022
      OPEN(1,FILE='f:\ASYIP\PORTFEL.DAT',FORM='UNFORMATTED')            TPOR0023
 4    READ(1) ((NXZ(I,J),I=1,10),J=1,4),(IW(I),I=1,NU),IQ,IP,ID,LZ,MP,NATPOR0024
     *,NS,NT                                                            TPOR0025
      IF(NA.LT.0) GOTO 8                                                TPOR0026
      READ(1) ((A(I,J),I=1,26),J=1,NA)                                  TPOR0027
      READ(1) ((S(I,J),I=1,2),J=1,NS),((P(I,J),I=1,2),J=1,NS)           TPOR0028
      READ(1) ((TQ(I,J),I=1,6),J=1,NT),((QZ(I,J),I=1,4),J=1,NT)         TPOR0029
      READ(1) ((TQC(I,J),I=1,4),J=1,NT)                                 TPOR0030
      DO 5 J=1,500                                                      TPOR0031
      IF(ZAK(1,J).EQ.C) GOTO 4                                          TPOR0032
      DO 6 I=1,4                                                        TPOR0033
      IF(NXZ(I,1).NE.ZAK(I,J)) GOTO 5                                   TPOR0034
 6    CONTINUE                                                          TPOR0035
      GOTO 7                                                            TPOR0036
 5    CONTINUE   
 7    izap=1
      WRITE(*,10)                                                       TPOR0037
      DO 20 I=1,NA
      WRITE (*,101) I,(A(J,I),J=1,26)                                   TPOR0038
      izap=izap+2
       if(izap.gt.23) pause'Для продолжения нажми кл."ENTER"' 
      if(izap.gt.23) izap=1 
 20   continue
      WRITE(*,11)
      izap=izap+1
      if(izap.eq.4) pause'Для продолжения нажми кл."ENTER"'
       if(izap.gt.23) pause'Для продолжения нажми кл."ENTER"' 
      if(izap.gt.23) izap=1
      DO 24 I=1,NS
      WRITE (*,111) I,(S(J,I),J=1,2),I,(P(J,I),J=1,2)                   TPOR0039
      izap=izap+1
       if(izap.gt.23) pause'Для продолжения нажми кл."ENTER"' 
      if(izap.gt.23) izap=1
  24  continue
      WRITE(*,12) 
      izap=izap+1
       if(izap.gt.23) pause'Для продолжения нажми кл."ENTER"' 
      if(izap.gt.23) izap=1
      DO 25 I=1,NT
      WRITE (*,121) I,(TQ(J,I),J=1,6),(QZ(J,I),J=1,4),(TQC(J,I),J=1,4)  TPOR0040
      izap=izap+2
       if(izap.gt.23) pause'Для продолжения нажми кл."ENTER"' 
      if(izap.gt.23) izap=1
  25  continue
      IK=NU/12                                                          TPOR0042
      KI=NU-IK*12                                                       TPOR0043
      WRITE (*,21)                                                      TPOR0044
      L=1                                                               TPOR0045
      K=12                                                              TPOR0046
      DO 23 I=1,IK                                                      TPOR0047
      WRITE (*,22) (IW(J),J=L,K)                                        TPOR0048
      K=K+12                                                            TPOR0049
      L=L+12                                                            TPOR0050
  23  CONTINUE                                                          TPOR0051
      IF(KI.EQ.0) GOTO 40                                               TPOR0052
      WRITE (*,22) (IW(J),J=L,NU)                                       TPOR0053
  40  WRITE (*,13) ((NXZ(J,I),J=1,10),I=1,4),IQ,IP,LZ,ID                TPOR0054
 13   FORMAT(1X,40A2,I5,2I3,I5)                                         TPOR0055
      GOTO 4                                                            TPOR0056
8     STOP                                                              TPOR0058
      END                                                               TPOR0059
