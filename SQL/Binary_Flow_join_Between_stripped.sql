select CASE    WHEN label = 'Bot' THEN 1	ELSE 0 END AS Bot	  ,[dst_port]      ,[flow_duration]      ,[tot_fwd_pkts]      ,[tot_bwd_pkts]      ,[totlen_fwd_pkts]      ,[totlen_bwd_pkts]      ,[fwd_pkt_len_max]      ,[fwd_pkt_len_min]      ,[fwd_pkt_len_mean]      ,[fwd_pkt_len_std]      ,[bwd_pkt_len_max]      ,[bwd_pkt_len_min]      ,[bwd_pkt_len_mean]      ,[bwd_pkt_len_std]      ,[flow_byts/s]      ,[flow_pkts/s]      ,[flow_iat_mean]      ,[flow_iat_std]      ,[flow_iat_max]      ,[flow_iat_min]      ,[fwd_iat_tot]      ,[fwd_iat_mean]      ,[fwd_iat_std]      ,[fwd_iat_max]      ,[fwd_iat_min]      ,[bwd_iat_tot]      ,[bwd_iat_mean]      ,[bwd_iat_std]      ,[bwd_iat_max]      ,[bwd_iat_min]      ,[fwd_psh_flags]      ,[bwd_psh_flags]      ,[fwd_urg_flags]      ,[bwd_urg_flags]      ,[fwd_header_len]      ,[bwd_header_len]      ,[fwd_pkts/s]      ,[bwd_pkts/s]      ,[pkt_len_min]      ,[pkt_len_max]      ,[pkt_len_mean]      ,[pkt_len_std]      ,[pkt_len_var]      ,[fin_flag_cnt]      ,[syn_flag_cnt]      ,[rst_flag_cnt]      ,[psh_flag_cnt]      ,[ack_flag_cnt]      ,[urg_flag_cnt]      ,[cwe_flag_count]      ,[ece_flag_cnt]      ,[down/up_ratio]      ,[pkt_size_avg]      ,[fwd_seg_size_avg]      ,[bwd_seg_size_avg]      ,[fwd_byts/b_avg]      ,[fwd_pkts/b_avg]      ,[fwd_blk_rate_avg]      ,[bwd_byts/b_avg]      ,[bwd_pkts/b_avg]      ,[bwd_blk_rate_avg]      ,[subflow_fwd_pkts]      ,[subflow_fwd_byts]      ,[subflow_bwd_pkts]      ,[subflow_bwd_byts]      ,[init_fwd_win_byts]      ,[init_bwd_win_byts]      ,[fwd_act_data_pkts]      ,[fwd_seg_size_min]      ,[active_mean]      ,[active_std]      ,[active_max]      ,[active_min]      ,[idle_mean]      ,[idle_std]      ,[idle_max]      ,[idle_min]	  ,[Tinyint1]      ,[Tinyint2]      ,[Tinyint3]      ,[Tinyint4]      ,[Tinyint5]      ,[Tinyint6]      ,[Tinyint7]      ,[Tinyint8]      ,[Tinyint9]      ,[Tinyint10]      ,[Tinyint11]      ,[Tinyint12]      ,[Tinyint13]      ,[Tinyint14]      ,[Tinyint15]      ,[Tinyint16]      ,[Tinyint17]      ,[Tinyint18]      ,[Tinyint19]      ,[Tinyint20]      ,[Tinyint21]      ,[Tinyint22]      ,[Tinyint23]      ,[Tinyint24]      ,[Tinyint25]      ,[Tinyint26]      ,[Tinyint27]      ,[Tinyint28]      ,[Tinyint29]      ,[Tinyint30]      ,[Tinyint31]      ,[Tinyint32]      ,[Tinyint33]      ,[Tinyint34]      ,[Tinyint35]      ,[Tinyint36]      ,[Tinyint37]      ,[Tinyint38]      ,[Tinyint39]      ,[Tinyint40]      ,[Tinyint41]      ,[Tinyint42]      ,[Tinyint43]      ,[Tinyint44]      ,[Tinyint45]      ,[Tinyint46]      ,[Tinyint47]      ,[Tinyint48]      ,[Tinyint49]      ,[Tinyint50]      ,[Tinyint51]      ,[Tinyint52]      ,[Tinyint53]      ,[Tinyint54]      ,[Tinyint55]      ,[Tinyint56]      ,[Tinyint57]      ,[Tinyint58]      ,[Tinyint59]      ,[Tinyint60]      ,[Tinyint61]      ,[Tinyint62]      ,[Tinyint63]      ,[Tinyint64]      ,[Tinyint65]      ,[Tinyint66]      ,[Tinyint67]      ,[Tinyint68]      ,[Tinyint69]      ,[Tinyint70]      ,[Tinyint71]      ,[Tinyint72]      ,[Tinyint73]      ,[Tinyint74]      ,[Tinyint75]      ,[Tinyint76]      ,[Tinyint77]      ,[Tinyint78]      ,[Tinyint79]      ,[Tinyint80]      ,[Tinyint81]      ,[Tinyint82]      ,[Tinyint83]      ,[Tinyint84]      ,[Tinyint85]      ,[Tinyint86]      ,[Tinyint87]      ,[Tinyint88]      ,[Tinyint89]      ,[Tinyint90]      ,[Tinyint91]      ,[Tinyint92]      ,[Tinyint93]      ,[Tinyint94]      ,[Tinyint95]      ,[Tinyint96]      ,[Tinyint97]      ,[Tinyint98]      ,[Tinyint99]      ,[Tinyint100]      ,[Tinyint101]      ,[Tinyint102]      ,[Tinyint103]      ,[Tinyint104]      ,[Tinyint105]      ,[Tinyint106]      ,[Tinyint107]      ,[Tinyint108]      ,[Tinyint109]      ,[Tinyint110]      ,[Tinyint111]      ,[Tinyint112]      ,[Tinyint113]      ,[Tinyint114]      ,[Tinyint115]      ,[Tinyint116]      ,[Tinyint117]      ,[Tinyint118]      ,[Tinyint119]      ,[Tinyint120]      ,[Tinyint121]      ,[Tinyint122]      ,[Tinyint123]      ,[Tinyint124]      ,[Tinyint125]      ,[Tinyint126]      ,[Tinyint127]      ,[Tinyint128]      ,[Tinyint129]      ,[Tinyint130]      ,[Tinyint131]      ,[Tinyint132]      ,[Tinyint133]      ,[Tinyint134]      ,[Tinyint135]      ,[Tinyint136]      ,[Tinyint137]      ,[Tinyint138]      ,[Tinyint139]      ,[Tinyint140]      ,[Tinyint141]      ,[Tinyint142]      ,[Tinyint143]      ,[Tinyint144]      ,[Tinyint145]      ,[Tinyint146]      ,[Tinyint147]      ,[Tinyint148]      ,[Tinyint149]      ,[Tinyint150]      ,[Tinyint151]      ,[Tinyint152]      ,[Tinyint153]      ,[Tinyint154]      ,[Tinyint155]      ,[Tinyint156]      ,[Tinyint157]      ,[Tinyint158]      ,[Tinyint159]      ,[Tinyint160]      ,[Tinyint161]      ,[Tinyint162]      ,[Tinyint163]      ,[Tinyint164]      ,[Tinyint165]      ,[Tinyint166]      ,[Tinyint167]      ,[Tinyint168]      ,[Tinyint169]      ,[Tinyint170]      ,[Tinyint171]      ,[Tinyint172]      ,[Tinyint173]      ,[Tinyint174]      ,[Tinyint175]      ,[Tinyint176]      ,[Tinyint177]      ,[Tinyint178]      ,[Tinyint179]      ,[Tinyint180]      ,[Tinyint181]      ,[Tinyint182]      ,[Tinyint183]      ,[Tinyint184]      ,[Tinyint185]      ,[Tinyint186]      ,[Tinyint187]      ,[Tinyint188]      ,[Tinyint189]      ,[Tinyint190]      ,[Tinyint191]      ,[Tinyint192]      ,[Tinyint193]      ,[Tinyint194]      ,[Tinyint195]      ,[Tinyint196]      ,[Tinyint197]      ,[Tinyint198]      ,[Tinyint199]      ,[Tinyint200]      ,[Tinyint201]      ,[Tinyint202]      ,[Tinyint203]      ,[Tinyint204]      ,[Tinyint205]      ,[Tinyint206]      ,[Tinyint207]      ,[Tinyint208]      ,[Tinyint209]      ,[Tinyint210]      ,[Tinyint211]      ,[Tinyint212]      ,[Tinyint213]      ,[Tinyint214]      ,[Tinyint215]      ,[Tinyint216]      ,[Tinyint217]      ,[Tinyint218]      ,[Tinyint219]      ,[Tinyint220]      ,[Tinyint221]      ,[Tinyint222]      ,[Tinyint223]      ,[Tinyint224]      ,[Tinyint225]      ,[Tinyint226]      ,[Tinyint227]      ,[Tinyint228]      ,[Tinyint229]      ,[Tinyint230]      ,[Tinyint231]      ,[Tinyint232]      ,[Tinyint233]      ,[Tinyint234]      ,[Tinyint235]      ,[Tinyint236]      ,[Tinyint237]      ,[Tinyint238]      ,[Tinyint239]      ,[Tinyint240]      ,[Tinyint241]      ,[Tinyint242]      ,[Tinyint243]      ,[Tinyint244]      ,[Tinyint245]      ,[Tinyint246]      ,[Tinyint247]      ,[Tinyint248]      ,[Tinyint249]      ,[Tinyint250]      ,[Tinyint251]      ,[Tinyint252]      ,[Tinyint253]      ,[Tinyint254]      ,[Tinyint255]      ,[Tinyint256]      ,[Tinyint257]      ,[Tinyint258]      ,[Tinyint259]      ,[Tinyint260]      ,[Tinyint261]      ,[Tinyint262]      ,[Tinyint263]      ,[Tinyint264]      ,[Tinyint265]      ,[Tinyint266]      ,[Tinyint267]      ,[Tinyint268]      ,[Tinyint269]      ,[Tinyint270]      ,[Tinyint271]      ,[Tinyint272]      ,[Tinyint273]      ,[Tinyint274]      ,[Tinyint275]      ,[Tinyint276]      ,[Tinyint277]      ,[Tinyint278]      ,[Tinyint279]      ,[Tinyint280]      ,[Tinyint281]      ,[Tinyint282]      ,[Tinyint283]      ,[Tinyint284]      ,[Tinyint285]      ,[Tinyint286]      ,[Tinyint287]      ,[Tinyint288]      ,[Tinyint289]      ,[Tinyint290]      ,[Tinyint291]      ,[Tinyint292]      ,[Tinyint293]      ,[Tinyint294]      ,[Tinyint295]      ,[Tinyint296]      ,[Tinyint297]      ,[Tinyint298]      ,[Tinyint299]      ,[Tinyint300]      ,[Tinyint301]      ,[Tinyint302]      ,[Tinyint303]      ,[Tinyint304]      ,[Tinyint305]      ,[Tinyint306]      ,[Tinyint307]      ,[Tinyint308]      ,[Tinyint309]      ,[Tinyint310]      ,[Tinyint311]      ,[Tinyint312]      ,[Tinyint313]      ,[Tinyint314]      ,[Tinyint315]      ,[Tinyint316]      ,[Tinyint317]      ,[Tinyint318]      ,[Tinyint319]      ,[Tinyint320]      ,[Tinyint321]      ,[Tinyint322]      ,[Tinyint323]      ,[Tinyint324]      ,[Tinyint325]      ,[Tinyint326]      ,[Tinyint327]      ,[Tinyint328]      ,[Tinyint329]      ,[Tinyint330]      ,[Tinyint331]      ,[Tinyint332]      ,[Tinyint333]      ,[Tinyint334]      ,[Tinyint335]      ,[Tinyint336]      ,[Tinyint337]      ,[Tinyint338]      ,[Tinyint339]      ,[Tinyint340]      ,[Tinyint341]      ,[Tinyint342]      ,[Tinyint343]      ,[Tinyint344]      ,[Tinyint345]      ,[Tinyint346]      ,[Tinyint347]      ,[Tinyint348]      ,[Tinyint349]      ,[Tinyint350]      ,[Tinyint351]      ,[Tinyint352]      ,[Tinyint353]      ,[Tinyint354]      ,[Tinyint355]      ,[Tinyint356]      ,[Tinyint357]      ,[Tinyint358]      ,[Tinyint359]      ,[Tinyint360]      ,[Tinyint361]      ,[Tinyint362]      ,[Tinyint363]      ,[Tinyint364]      ,[Tinyint365]      ,[Tinyint366]      ,[Tinyint367]      ,[Tinyint368]      ,[Tinyint369]      ,[Tinyint370]      ,[Tinyint371]      ,[Tinyint372]      ,[Tinyint373]      ,[Tinyint374]      ,[Tinyint375]      ,[Tinyint376]      ,[Tinyint377]      ,[Tinyint378]      ,[Tinyint379]      ,[Tinyint380]      ,[Tinyint381]      ,[Tinyint382]      ,[Tinyint383]      ,[Tinyint384]      ,[Tinyint385]      ,[Tinyint386]      ,[Tinyint387]      ,[Tinyint388]      ,[Tinyint389]      ,[Tinyint390]      ,[Tinyint391]      ,[Tinyint392]      ,[Tinyint393]      ,[Tinyint394]      ,[Tinyint395]      ,[Tinyint396]      ,[Tinyint397]      ,[Tinyint398]      ,[Tinyint399]      ,[Tinyint400]      ,[Tinyint401]      ,[Tinyint402]      ,[Tinyint403]      ,[Tinyint404]      ,[Tinyint405]      ,[Tinyint406]      ,[Tinyint407]      ,[Tinyint408]      ,[Tinyint409]      ,[Tinyint410]      ,[Tinyint411]      ,[Tinyint412]      ,[Tinyint413]      ,[Tinyint414]      ,[Tinyint415]      ,[Tinyint416]      ,[Tinyint417]      ,[Tinyint418]      ,[Tinyint419]      ,[Tinyint420]      ,[Tinyint421]      ,[Tinyint422]      ,[Tinyint423]      ,[Tinyint424]      ,[Tinyint425]      ,[Tinyint426]      ,[Tinyint427]      ,[Tinyint428]      ,[Tinyint429]      ,[Tinyint430]      ,[Tinyint431]      ,[Tinyint432]      ,[Tinyint433]      ,[Tinyint434]      ,[Tinyint435]      ,[Tinyint436]      ,[Tinyint437]      ,[Tinyint438]      ,[Tinyint439]      ,[Tinyint440]      ,[Tinyint441]      ,[Tinyint442]      ,[Tinyint443]      ,[Tinyint444]      ,[Tinyint445]      ,[Tinyint446]      ,[Tinyint447]      ,[Tinyint448]      ,[Tinyint449]      ,[Tinyint450]      ,[Tinyint451]      ,[Tinyint452]      ,[Tinyint453]      ,[Tinyint454]      ,[Tinyint455]      ,[Tinyint456]      ,[Tinyint457]      ,[Tinyint458]      ,[Tinyint459]      ,[Tinyint460]      ,[Tinyint461]      ,[Tinyint462]      ,[Tinyint463]      ,[Tinyint464]      ,[Tinyint465]      ,[Tinyint466]      ,[Tinyint467]      ,[Tinyint468]      ,[Tinyint469]      ,[Tinyint470]      ,[Tinyint471]      ,[Tinyint472]      ,[Tinyint473]      ,[Tinyint474]      ,[Tinyint475]      ,[Tinyint476]      ,[Tinyint477]      ,[Tinyint478]      ,[Tinyint479]      ,[Tinyint480]      ,[Tinyint481]      ,[Tinyint482]      ,[Tinyint483]      ,[Tinyint484]      ,[Tinyint485]      ,[Tinyint486]      ,[Tinyint487]      ,[Tinyint488]      ,[Tinyint489]      ,[Tinyint490]      ,[Tinyint491]      ,[Tinyint492]      ,[Tinyint493]      ,[Tinyint494]      ,[Tinyint495]      ,[Tinyint496]      ,[Tinyint497]      ,[Tinyint498]      ,[Tinyint499]      ,[Tinyint500]      ,[Tinyint501]      ,[Tinyint502]      ,[Tinyint503]      ,[Tinyint504]      ,[Tinyint505]      ,[Tinyint506]      ,[Tinyint507]      ,[Tinyint508]      ,[Tinyint509]      ,[Tinyint510]      ,[Tinyint511]      ,[Tinyint512]      ,[Tinyint513]      ,[Tinyint514]      ,[Tinyint515]      ,[Tinyint516]      ,[Tinyint517]      ,[Tinyint518]      ,[Tinyint519]      ,[Tinyint520]      ,[Tinyint521]      ,[Tinyint522]      ,[Tinyint523]      ,[Tinyint524]      ,[Tinyint525]      ,[Tinyint526]      ,[Tinyint527]      ,[Tinyint528]      ,[Tinyint529]      ,[Tinyint530]      ,[Tinyint531]      ,[Tinyint532]      ,[Tinyint533]      ,[Tinyint534]      ,[Tinyint535]      ,[Tinyint536]      ,[Tinyint537]      ,[Tinyint538]      ,[Tinyint539]      ,[Tinyint540]      ,[Tinyint541]      ,[Tinyint542]      ,[Tinyint543]      ,[Tinyint544]      ,[Tinyint545]      ,[Tinyint546]      ,[Tinyint547]      ,[Tinyint548]      ,[Tinyint549]      ,[Tinyint550]      ,[Tinyint551]      ,[Tinyint552]      ,[Tinyint553]      ,[Tinyint554]      ,[Tinyint555]      ,[Tinyint556]      ,[Tinyint557]      ,[Tinyint558]      ,[Tinyint559]      ,[Tinyint560]      ,[Tinyint561]      ,[Tinyint562]      ,[Tinyint563]      ,[Tinyint564]      ,[Tinyint565]      ,[Tinyint566]      ,[Tinyint567]      ,[Tinyint568]      ,[Tinyint569]      ,[Tinyint570]      ,[Tinyint571]      ,[Tinyint572]      ,[Tinyint573]      ,[Tinyint574]      ,[Tinyint575]      ,[Tinyint576]      ,[Tinyint577]      ,[Tinyint578]      ,[Tinyint579]      ,[Tinyint580]      ,[Tinyint581]      ,[Tinyint582]      ,[Tinyint583]      ,[Tinyint584]      ,[Tinyint585]      ,[Tinyint586]      ,[Tinyint587]      ,[Tinyint588]      ,[Tinyint589]      ,[Tinyint590]      ,[Tinyint591]      ,[Tinyint592]      ,[Tinyint593]      ,[Tinyint594]      ,[Tinyint595]      ,[Tinyint596]      ,[Tinyint597]      ,[Tinyint598]      ,[Tinyint599]      ,[Tinyint600]      ,[Tinyint601]      ,[Tinyint602]      ,[Tinyint603]      ,[Tinyint604]      ,[Tinyint605]      ,[Tinyint606]      ,[Tinyint607]      ,[Tinyint608]      ,[Tinyint609]      ,[Tinyint610]      ,[Tinyint611]      ,[Tinyint612]      ,[Tinyint613]      ,[Tinyint614]      ,[Tinyint615]      ,[Tinyint616]      ,[Tinyint617]      ,[Tinyint618]      ,[Tinyint619]      ,[Tinyint620]      ,[Tinyint621]      ,[Tinyint622]      ,[Tinyint623]      ,[Tinyint624]      ,[Tinyint625]      ,[Tinyint626]      ,[Tinyint627]      ,[Tinyint628]      ,[Tinyint629]      ,[Tinyint630]      ,[Tinyint631]      ,[Tinyint632]      ,[Tinyint633]      ,[Tinyint634]      ,[Tinyint635]      ,[Tinyint636]      ,[Tinyint637]      ,[Tinyint638]      ,[Tinyint639]      ,[Tinyint640]      ,[Tinyint641]      ,[Tinyint642]      ,[Tinyint643]      ,[Tinyint644]      ,[Tinyint645]      ,[Tinyint646]      ,[Tinyint647]      ,[Tinyint648]      ,[Tinyint649]      ,[Tinyint650]      ,[Tinyint651]      ,[Tinyint652]      ,[Tinyint653]      ,[Tinyint654]      ,[Tinyint655]      ,[Tinyint656]      ,[Tinyint657]      ,[Tinyint658]      ,[Tinyint659]      ,[Tinyint660]      ,[Tinyint661]      ,[Tinyint662]      ,[Tinyint663]      ,[Tinyint664]      ,[Tinyint665]      ,[Tinyint666]      ,[Tinyint667]      ,[Tinyint668]      ,[Tinyint669]      ,[Tinyint670]      ,[Tinyint671]      ,[Tinyint672]      ,[Tinyint673]      ,[Tinyint674]      ,[Tinyint675]      ,[Tinyint676]      ,[Tinyint677]      ,[Tinyint678]      ,[Tinyint679]      ,[Tinyint680]      ,[Tinyint681]      ,[Tinyint682]      ,[Tinyint683]      ,[Tinyint684]      ,[Tinyint685]      ,[Tinyint686]      ,[Tinyint687]      ,[Tinyint688]      ,[Tinyint689]      ,[Tinyint690]      ,[Tinyint691]      ,[Tinyint692]      ,[Tinyint693]      ,[Tinyint694]      ,[Tinyint695]      ,[Tinyint696]      ,[Tinyint697]      ,[Tinyint698]      ,[Tinyint699]      ,[Tinyint700]      ,[Tinyint701]      ,[Tinyint702]      ,[Tinyint703]      ,[Tinyint704]      ,[Tinyint705]      ,[Tinyint706]      ,[Tinyint707]      ,[Tinyint708]      ,[Tinyint709]      ,[Tinyint710]      ,[Tinyint711]      ,[Tinyint712]      ,[Tinyint713]      ,[Tinyint714]      ,[Tinyint715]      ,[Tinyint716]      ,[Tinyint717]      ,[Tinyint718]      ,[Tinyint719]      ,[Tinyint720]      ,[Tinyint721]      ,[Tinyint722]      ,[Tinyint723]      ,[Tinyint724]      ,[Tinyint725]      ,[Tinyint726]      ,[Tinyint727]      ,[Tinyint728]      ,[Tinyint729]      ,[Tinyint730]      ,[Tinyint731]      ,[Tinyint732]      ,[Tinyint733]      ,[Tinyint734]      ,[Tinyint735]      ,[Tinyint736]      ,[Tinyint737]      ,[Tinyint738]      ,[Tinyint739]      ,[Tinyint740]      ,[Tinyint741]      ,[Tinyint742]      ,[Tinyint743]      ,[Tinyint744]      ,[Tinyint745]      ,[Tinyint746]      ,[Tinyint747]      ,[Tinyint748]      ,[Tinyint749]      ,[Tinyint750]      ,[Tinyint751]      ,[Tinyint752]      ,[Tinyint753]      ,[Tinyint754]      ,[Tinyint755]      ,[Tinyint756]      ,[Tinyint757]      ,[Tinyint758]      ,[Tinyint759]      ,[Tinyint760]      ,[Tinyint761]      ,[Tinyint762]      ,[Tinyint763]      ,[Tinyint764]      ,[Tinyint765]      ,[Tinyint766]      ,[Tinyint767]      ,[Tinyint768]      ,[Tinyint769]      ,[Tinyint770]      ,[Tinyint771]      ,[Tinyint772]      ,[Tinyint773]      ,[Tinyint774]      ,[Tinyint775]      ,[Tinyint776]      ,[Tinyint777]      ,[Tinyint778]      ,[Tinyint779]      ,[Tinyint780]      ,[Tinyint781]      ,[Tinyint782]      ,[Tinyint783]      ,[Tinyint784]      ,[Tinyint785]      ,[Tinyint786]      ,[Tinyint787]      ,[Tinyint788]      ,[Tinyint789]      ,[Tinyint790]      ,[Tinyint791]      ,[Tinyint792]      ,[Tinyint793]      ,[Tinyint794]      ,[Tinyint795]      ,[Tinyint796]      ,[Tinyint797]      ,[Tinyint798]      ,[Tinyint799]      ,[Tinyint800]      ,[Tinyint801]      ,[Tinyint802]      ,[Tinyint803]      ,[Tinyint804]      ,[Tinyint805]      ,[Tinyint806]      ,[Tinyint807]      ,[Tinyint808]      ,[Tinyint809]      ,[Tinyint810]      ,[Tinyint811]      ,[Tinyint812]      ,[Tinyint813]      ,[Tinyint814]      ,[Tinyint815]      ,[Tinyint816]      ,[Tinyint817]      ,[Tinyint818]      ,[Tinyint819]      ,[Tinyint820]      ,[Tinyint821]      ,[Tinyint822]      ,[Tinyint823]      ,[Tinyint824]      ,[Tinyint825]      ,[Tinyint826]      ,[Tinyint827]      ,[Tinyint828]      ,[Tinyint829]      ,[Tinyint830]      ,[Tinyint831]      ,[Tinyint832]      ,[Tinyint833]      ,[Tinyint834]      ,[Tinyint835]      ,[Tinyint836]      ,[Tinyint837]      ,[Tinyint838]      ,[Tinyint839]      ,[Tinyint840]      ,[Tinyint841]      ,[Tinyint842]      ,[Tinyint843]      ,[Tinyint844]      ,[Tinyint845]      ,[Tinyint846]      ,[Tinyint847]      ,[Tinyint848]      ,[Tinyint849]      ,[Tinyint850]      ,[Tinyint851]      ,[Tinyint852]      ,[Tinyint853]      ,[Tinyint854]      ,[Tinyint855]      ,[Tinyint856]      ,[Tinyint857]      ,[Tinyint858]      ,[Tinyint859]      ,[Tinyint860]      ,[Tinyint861]      ,[Tinyint862]      ,[Tinyint863]      ,[Tinyint864]      ,[Tinyint865]      ,[Tinyint866]      ,[Tinyint867]      ,[Tinyint868]      ,[Tinyint869]      ,[Tinyint870]      ,[Tinyint871]      ,[Tinyint872]      ,[Tinyint873]      ,[Tinyint874]      ,[Tinyint875]      ,[Tinyint876]      ,[Tinyint877]      ,[Tinyint878]      ,[Tinyint879]      ,[Tinyint880]      ,[Tinyint881]      ,[Tinyint882]      ,[Tinyint883]      ,[Tinyint884]      ,[Tinyint885]      ,[Tinyint886]      ,[Tinyint887]      ,[Tinyint888]      ,[Tinyint889]      ,[Tinyint890]      ,[Tinyint891]      ,[Tinyint892]      ,[Tinyint893]      ,[Tinyint894]      ,[Tinyint895]      ,[Tinyint896]      ,[Tinyint897]      ,[Tinyint898]      ,[Tinyint899]      ,[Tinyint900]      ,[Tinyint901]      ,[Tinyint902]      ,[Tinyint903]      ,[Tinyint904]      ,[Tinyint905]      ,[Tinyint906]      ,[Tinyint907]      ,[Tinyint908]      ,[Tinyint909]      ,[Tinyint910]      ,[Tinyint911]      ,[Tinyint912]      ,[Tinyint913]      ,[Tinyint914]      ,[Tinyint915]      ,[Tinyint916]      ,[Tinyint917]      ,[Tinyint918]      ,[Tinyint919]      ,[Tinyint920]      ,[Tinyint921]      ,[Tinyint922]      ,[Tinyint923]      ,[Tinyint924]      ,[Tinyint925]      ,[Tinyint926]      ,[Tinyint927]      ,[Tinyint928]      ,[Tinyint929]      ,[Tinyint930]      ,[Tinyint931]      ,[Tinyint932]      ,[Tinyint933]      ,[Tinyint934]      ,[Tinyint935]      ,[Tinyint936]      ,[Tinyint937]      ,[Tinyint938]      ,[Tinyint939]      ,[Tinyint940]      ,[Tinyint941]      ,[Tinyint942]      ,[Tinyint943]      ,[Tinyint944]      ,[Tinyint945]      ,[Tinyint946]      ,[Tinyint947]      ,[Tinyint948]      ,[Tinyint949]      ,[Tinyint950]      ,[Tinyint951]      ,[Tinyint952]      ,[Tinyint953]      ,[Tinyint954]      ,[Tinyint955]      ,[Tinyint956]      ,[Tinyint957]      ,[Tinyint958]      ,[Tinyint959]      ,[Tinyint960]      ,[Tinyint961]      ,[Tinyint962]      ,[Tinyint963]      ,[Tinyint964]      ,[Tinyint965]      ,[Tinyint966]      ,[Tinyint967]      ,[Tinyint968]      ,[Tinyint969]      ,[Tinyint970]      ,[Tinyint971]      ,[Tinyint972]      ,[Tinyint973]      ,[Tinyint974]      ,[Tinyint975]      ,[Tinyint976]      ,[Tinyint977]      ,[Tinyint978]      ,[Tinyint979]      ,[Tinyint980]      ,[Tinyint981]      ,[Tinyint982]      ,[Tinyint983]      ,[Tinyint984]      ,[Tinyint985]      ,[Tinyint986]      ,[Tinyint987]      ,[Tinyint988]      ,[Tinyint989]      ,[Tinyint990]      ,[Tinyint991]      ,[Tinyint992]      ,[Tinyint993]      ,[Tinyint994]      ,[Tinyint995]      ,[Tinyint996]      ,[Tinyint997]      ,[Tinyint998]      ,[Tinyint999]      ,[Tinyint1000] from  gann.dbo.binary_data b inner join gann.dbo.flow_data fd on fd.timestamp between b.startime and b.endtime inner join gann.[dbo].[TinyInt] ti on b.idx = ti.binary_data_idx where label = 'Bot' OR label = 'Benign' AND protocol = 6 order by timestamp asc