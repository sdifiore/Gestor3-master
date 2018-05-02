using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PlanejVendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanejVendas
        public ActionResult Index(int? page)
        {
            ViewBag.incremento = db.Memorias.First().PvIncrementoGlobal * 100;
            ViewBag.despExp = db.Memorias.First().DespExp * 100;

            var planejVendas = db.PlanejVendas
                .Include(p => p.Produto)
                .OrderBy(p => p.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = planejVendas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PlanejVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlanejVenda planejVenda = db.PlanejVendas
                .Include(p => p.Produto)
                .SingleOrDefault(p => p.Id == id);

            if (planejVenda == null)
            {
                return HttpNotFound();
            }
            return View(planejVenda);
        }

        // GET: PlanejVendas/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            return View();
        }

        // POST: PlanejVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,PesoUnitario,HorasMod,CustoDiretoTotal,CustoDiretoMats,CustoDiretoMod,CustoFixoFabrica,CustoFixAdmCom,AliquotaIpi,QvQtNacAnoMenos12,QvQtNacAnoMenos11,QvQtNacAnoMenos10,QvQtNacAnoMenos9,QvQtNacAnoMenos8,QvQtNacAnoMenos7,QvQtNacAnoMenos6,QvQtNacAnoMenos5,QvQtNacAnoMenos4,QvQtNacAnoMenos3,QvQtNacAnoMenos2,QvQtNacAno,QtNacMediaMensal,PvMed1o3m,PvMed2o3m,PvMed3o3m,PvMed4o3m,PvNacAdotado,StMedia,IcmsMedio,ComissaoMediaNac,FreteNacPct,MesRecebMedNac,QtExpAnoMenos12,QtExpAnoMenos11,QtExpAnoMenos10,QtExpAnoMenos9,QtExpAnoMenos8,QtExpAnoMenos7,QtExpAnoMenos6,QtExpAnoMenos5,QtExpAnoMenos4,QtExpAnoMenos3,QtExpAnoMenos2,QtExpAno,QtExpMediaMensal,PvMedEx1o3m,PvMedEx2o3m,PvMedEx3o3m,PvMedEx4o3m,PvMedExAdotado,ComissaoExpPct,PrazoRecebMedExp,ComentarioCelulaBi,Criterio,VartC1,VarTc2,VartC3,VartC4,PqQtNacAnoMenos12,PqQtNacAnoMenos11,PqQtNacAnoMenos10,PqQtNacAnoMenos9,PqQtNacAnoMenos8,PqQtNacAnoMenos7,PqQtNacAnoMenos6,PqQtNacAnoMenos5,PqQtNacAnoMenos4,PqQtNacAnoMenos3,PqQtNacAnoMenos2,PqQtNacAno,PqQtNacTotal,PplKgNacAnoMenos12,PplKgNacAnoMenos11,PplKgNacAnoMenos10,PplKgNacAnoMenos9,PplKgNacAnoMenos8,PplKgNacAnoMenos7,PplKgNacAnoMenos6,PplKgNacAnoMenos5,PplKgNacAnoMenos4,PplKgNacAnoMenos3,PplKgNacAnoMenos2,PplKgNacAno,PplKgNacTotal,PvvpvaVarPvAnoMenos12,PvvpvaVarPvAnoMenos11,PvvpvaVarPvAnoMenos10,PvvpvaVarPvAnoMenos9,PvvpvaVarPvAnoMenos8,PvvpvaVarPvAnoMenos7,PvvpvaVarPvAnoMenos6,PvvpvaVarPvAnoMenos5,PvvpvaVarPvAnoMenos4,PvvpvaVarPvAnoMenos3,PvvpvaVarPvAnoMenos2,PvvpvaVarPvAno,PcbRbNacAnoMenos12,PcbRbNacAnoMenos11,PcbRbNacAnoMenos10,PcbRbNacAnoMenos9,PcbRbNacAnoMenos8,PcbRbNacAnoMenos7,PcbRbNacAnoMenos6,PcbRbNacAnoMenos5,PcbRbNacAnoMenos4,PcbRbNacAnoMenos3,PcbRbNacAnoMenos2,PcbRbNacAno,PcbRbNacTotal,PipiIpiNacAnoMenos12,PipiIpiNacAnoMenos11,PipiIpiNacAnoMenos10,PipiIpiNacAnoMenos9,PipiIpiNacAnoMenos8,PipiIpiNacAnoMenos7,PipiIpiNacAnoMenos6,PipiIpiNacAnoMenos5,PipiIpiNacAnoMenos4,PipiIpiNacAnoMenos3,PipiIpiNacAnoMenos2,PipiIpiNacAno,PstStNacAnoMenos12,PstStNacAnoMenos11,PstStNacAnoMenos10,PstStNacAnoMenos9,PstStNacAnoMenos8,PstStNacAnoMenos7,PstStNacAnoMenos6,PstStNacAnoMenos5,PstStNacAnoMenos4,PstStNacAnoMenos3,PstStNacAnoMenos2,PstStNacAno,PfbFatBrAnoMenos12,PfbFatBrAnoMenos11,PfbFatBrAnoMenos10,PfbFatBrAnoMenos9,PfbFatBrAnoMenos8,PfbFatBrAnoMenos7,PfbFatBrAnoMenos6,PfbFatBrAnoMenos5,PfbFatBrAnoMenos4,PfbFatBrAnoMenos3,PfbFatBrAnoMenos2,PfbFatBrAno,PicmsIcmsNacAnoMenos12,PicmsIcmsNacAnoMenos11,PicmsIcmsNacAnoMenos10,PicmsIcmsNacAnoMenos9,PicmsIcmsNacAnoMenos8,PicmsIcmsNacAnoMenos7,PicmsIcmsNacAnoMenos6,PicmsIcmsNacAnoMenos5,PicmsIcmsNacAnoMenos4,PicmsIcmsNacAnoMenos3,PicmsIcmsNacAnoMenos2,PicmsIcmsNacAno,CrnFatBrutoNac,CrnImpostos,CrnRecLiquidaNacional,CrnComissaoNac,CrnFreteNac,CrnRecLiquidaVendaNac,CrnCustoDirMateriaisNac,CrnCustoDirModNac,CrnFixoFabricaNac,CrnMCNac,CrnMCNacPct,CrnCustoFixoAdmComNac,CrnResultadoBrutoNac,CrnResultadoBrutoNacPct,CrnComentario,PqeCriterio,PqeAumDim,PqeQtExpAnoMenos12,PqeQtExpAnoMenos11,PqeQtExpAnoMenos10,PqeQtExpAnoMenos9,PqeQtExpAnoMenos8,PqeQtExpAnoMenos7,PqeQtExpAnoMenos6,PqeQtExpAnoMenos5,PqeQtExpAnoMenos4,PqeQtExpAnoMenos3,PqeQtExpAnoMenos2,PqeQtExpAno,PqeQtExpTotal,PpleKgExpAnoMenos12,PpleKgExpAnoMenos11,PpleKgExpAnoMenos10,PpleKgExpAnoMenos9,PpleKgExpAnoMenos8,PpleKgExpAnoMenos7,PpleKgExpAnoMenos6,PpleKgExpAnoMenos5,PpleKgExpAnoMenos4,PpleKgExpAnoMenos3,PpleKgExpAnoMenos2,PpleKgExpAno,PpleKgExpTotal,PvppvaVPVexAnoMenos12,PvppvaVPVexAnoMenos11,PvppvaVPVexAnoMenos10,PvppvaVPVexAnoMenos9,PvppvaVPVexAnoMenos8,PvppvaVPVexAnoMenos7,PvppvaVPVexAnoMenos6,PvppvaVPVexAnoMenos5,PvppvaVPVexAnoMenos4,PvppvaVPVexAnoMenos3,PvppvaVPVexAnoMenos2,PvppvaVPVexAno,PreUsdRcExpUsAnoMenos12,PreUsdRcExpUsAnoMenos11,PreUsdRcExpUsAnoMenos10,PreUsdRcExpUsAnoMenos9,PreUsdRcExpUsAnoMenos8,PreUsdRcExpUsAnoMenos7,PreUsdRcExpUsAnoMenos6,PreUsdRcExpUsAnoMenos5,PreUsdRcExpUsAnoMenos4,PreUsdRcExpUsAnoMenos3,PreUsdRcExpUsAnoMenos2,PreUsdRcExpUsAno,PreUsdRcExpUsRecExportUSD,CreRecExportRs,CreComissaoExportRs,CreFreteDespExportRs,CreRecLiqVendaExportRs,CreCustoDiretoMatModExptRs,CreCustoFixoFabExpRs,CreMCExportRs,CreMCExportPct,CreCustoFixoAdmComExpRs,CreResultadoBrutoExpRs,CreResBrutoExpPct,FbQuantTotal,FbPesoTotal,FbFaturamentoBrutoTotal,RlImpostoTotal,RlReceitaLiquidaTotal,RlComissaoTotal,RlFreteDespExpTotal,RlRecLiqVendaTotal,McCustoDirMatModTotal,McCustoFixoFabricaTotal,McMargemContribTotal,McMCbTotalPct,RoCustoFixoComAdmTotal,RoCustoFixoComAdmAjustadoTotal,RoResultadoOperacionalTotal,RoResultadoOperacionalTotalPct,CdTotAnoMenos12,CdTotAnoMenos11,CdTotAnoMenos10,CdTotAnoMenos9,CdTotAnoMenos8,CdTotAnoMenos7,CdTotAnoMenos6,CdTotAnoMenos5,CdTotAnoMenos4,CdTotAnoMenos3,CdTotAnoMenos2,CdTotAno,GifTotAnoMenos12,GifTotAnoMenos11,GifTotAnoMenos10,GifTotAnoMenos9,GifTotAnoMenos8,GifTotAnoMenos7,GifTotAnoMenos6,GifTotAnoMenos5,GifTotAnoMenos4,GifTotAnoMenos3,GifTotAnoMenos2,GifTotAno,ComTotAnoMenos12,ComTotAnoMenos11,ComTotAnoMenos10,ComTotAnoMenos9,ComTotAnoMenos8,ComTotAnoMenos7,ComTotAnoMenos6,ComTotAnoMenos5,ComTotAnoMenos4,ComTotAnoMenos3,ComTotAnoMenos2,ComTotAno,FrtNacAnoMenos12,FrtNacAnoMenos11,FrtNacAnoMenos10,FrtNacAnoMenos9,FrtNacAnoMenos8,FrtNacAnoMenos7,FrtNacAnoMenos6,FrtNacAnoMenos5,FrtNacAnoMenos4,FrtNacAnoMenos3,FrtNacAnoMenos2,FrtNacAno,FrDexpAnoMenos12,FrDexpAnoMenos11,FrDexpAnoMenos10,FrDexpAnoMenos9,FrDexpAnoMenos8,FrDexpAnoMenos7,FrDexpAnoMenos6,FrDexpAnoMenos5,FrDexpAnoMenos4,FrDexpAnoMenos3,FrDexpAnoMenos2,FrDexpAno,CdsmtCfMatAnoMenos12,CdsmtCfMatAnoMenos11,CdsmtCfMatAnoMenos10,CdsmtCfMatAnoMenos9,CdsmtCfMatAnoMenos8,CdsmtCfMatAnoMenos7,CdsmtCfMatAnoMenos6,CdsmtCfMatAnoMenos5,CdsmtCfMatAnoMenos4,CdsmtCfMatAnoMenos3,CdsmtCfMatAnoMenos2,CdsmtCfMatAno,QtvQtTottAnoMenos12,QtvQtTottAnoMenos11,QtvQtTottAnoMenos10,QtvQtTottAnoMenos9,QtvQtTottAnoMenos8,QtvQtTottAnoMenos7,QtvQtTottAnoMenos6,QtvQtTottAnoMenos5,QtvQtTottAnoMenos4,QtvQtTottAnoMenos3,QtvQtTottAnoMenos2,QtvQtTottAno,HorasProdAnoMenos12,HorasProdAnoMenos11,HorasProdAnoMenos10,HorasProdAnoMenos9,HorasProdAnoMenos8,HorasProdAnoMenos7,HorasProdAnoMenos6,HorasProdAnoMenos5,HorasProdAnoMenos4,HorasProdAnoMenos3,HorasProdAnoMenos2,HorasProdAno,RecNacAnoMenos12,RecNacAnoMenos11,RecNacAnoMenos10,RecNacAnoMenos9,RecNacAnoMenos8,RecNacAnoMenos7,RecNacAnoMenos6,RecNacAnoMenos5,RecNacAnoMenos4,RecNacAnoMenos3,RecNacAnoMenos2,RecNacAno,RecExpAnoMenos12,RecExpAnoMenos11,RecExpAnoMenos10,RecExpAnoMenos9,RecExpAnoMenos8,RecExpAnoMenos7,RecExpAnoMenos6,RecExpAnoMenos5,RecExpAnoMenos4,RecExpAnoMenos3,RecExpAnoMenos2,RecExpAno")] PlanejVenda planejVenda)
        {
            if (ModelState.IsValid)
            {
                db.PlanejVendas.Add(planejVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", planejVenda.ProdutoId);
            return View(planejVenda);
        }

        // GET: PlanejVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanejVenda planejVenda = db.PlanejVendas.Find(id);
            if (planejVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", planejVenda.ProdutoId);
            return View(planejVenda);
        }

        // POST: PlanejVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,PesoUnitario,HorasMod,CustoDiretoTotal,CustoDiretoMats,CustoDiretoMod,CustoFixoFabrica,CustoFixAdmCom,AliquotaIpi,QvQtNacAnoMenos12,QvQtNacAnoMenos11,QvQtNacAnoMenos10,QvQtNacAnoMenos9,QvQtNacAnoMenos8,QvQtNacAnoMenos7,QvQtNacAnoMenos6,QvQtNacAnoMenos5,QvQtNacAnoMenos4,QvQtNacAnoMenos3,QvQtNacAnoMenos2,QvQtNacAno,QtNacMediaMensal,PvMed1o3m,PvMed2o3m,PvMed3o3m,PvMed4o3m,PvNacAdotado,StMedia,IcmsMedio,ComissaoMediaNac,FreteNacPct,MesRecebMedNac,QtExpAnoMenos12,QtExpAnoMenos11,QtExpAnoMenos10,QtExpAnoMenos9,QtExpAnoMenos8,QtExpAnoMenos7,QtExpAnoMenos6,QtExpAnoMenos5,QtExpAnoMenos4,QtExpAnoMenos3,QtExpAnoMenos2,QtExpAno,QtExpMediaMensal,PvMedEx1o3m,PvMedEx2o3m,PvMedEx3o3m,PvMedEx4o3m,PvMedExAdotado,ComissaoExpPct,PrazoRecebMedExp,ComentarioCelulaBi,Criterio,VartC1,VarTc2,VartC3,VartC4,PqQtNacAnoMenos12,PqQtNacAnoMenos11,PqQtNacAnoMenos10,PqQtNacAnoMenos9,PqQtNacAnoMenos8,PqQtNacAnoMenos7,PqQtNacAnoMenos6,PqQtNacAnoMenos5,PqQtNacAnoMenos4,PqQtNacAnoMenos3,PqQtNacAnoMenos2,PqQtNacAno,PqQtNacTotal,PplKgNacAnoMenos12,PplKgNacAnoMenos11,PplKgNacAnoMenos10,PplKgNacAnoMenos9,PplKgNacAnoMenos8,PplKgNacAnoMenos7,PplKgNacAnoMenos6,PplKgNacAnoMenos5,PplKgNacAnoMenos4,PplKgNacAnoMenos3,PplKgNacAnoMenos2,PplKgNacAno,PplKgNacTotal,PvvpvaVarPvAnoMenos12,PvvpvaVarPvAnoMenos11,PvvpvaVarPvAnoMenos10,PvvpvaVarPvAnoMenos9,PvvpvaVarPvAnoMenos8,PvvpvaVarPvAnoMenos7,PvvpvaVarPvAnoMenos6,PvvpvaVarPvAnoMenos5,PvvpvaVarPvAnoMenos4,PvvpvaVarPvAnoMenos3,PvvpvaVarPvAnoMenos2,PvvpvaVarPvAno,PcbRbNacAnoMenos12,PcbRbNacAnoMenos11,PcbRbNacAnoMenos10,PcbRbNacAnoMenos9,PcbRbNacAnoMenos8,PcbRbNacAnoMenos7,PcbRbNacAnoMenos6,PcbRbNacAnoMenos5,PcbRbNacAnoMenos4,PcbRbNacAnoMenos3,PcbRbNacAnoMenos2,PcbRbNacAno,PcbRbNacTotal,PipiIpiNacAnoMenos12,PipiIpiNacAnoMenos11,PipiIpiNacAnoMenos10,PipiIpiNacAnoMenos9,PipiIpiNacAnoMenos8,PipiIpiNacAnoMenos7,PipiIpiNacAnoMenos6,PipiIpiNacAnoMenos5,PipiIpiNacAnoMenos4,PipiIpiNacAnoMenos3,PipiIpiNacAnoMenos2,PipiIpiNacAno,PstStNacAnoMenos12,PstStNacAnoMenos11,PstStNacAnoMenos10,PstStNacAnoMenos9,PstStNacAnoMenos8,PstStNacAnoMenos7,PstStNacAnoMenos6,PstStNacAnoMenos5,PstStNacAnoMenos4,PstStNacAnoMenos3,PstStNacAnoMenos2,PstStNacAno,PfbFatBrAnoMenos12,PfbFatBrAnoMenos11,PfbFatBrAnoMenos10,PfbFatBrAnoMenos9,PfbFatBrAnoMenos8,PfbFatBrAnoMenos7,PfbFatBrAnoMenos6,PfbFatBrAnoMenos5,PfbFatBrAnoMenos4,PfbFatBrAnoMenos3,PfbFatBrAnoMenos2,PfbFatBrAno,PicmsIcmsNacAnoMenos12,PicmsIcmsNacAnoMenos11,PicmsIcmsNacAnoMenos10,PicmsIcmsNacAnoMenos9,PicmsIcmsNacAnoMenos8,PicmsIcmsNacAnoMenos7,PicmsIcmsNacAnoMenos6,PicmsIcmsNacAnoMenos5,PicmsIcmsNacAnoMenos4,PicmsIcmsNacAnoMenos3,PicmsIcmsNacAnoMenos2,PicmsIcmsNacAno,CrnFatBrutoNac,CrnImpostos,CrnRecLiquidaNacional,CrnComissaoNac,CrnFreteNac,CrnRecLiquidaVendaNac,CrnCustoDirMateriaisNac,CrnCustoDirModNac,CrnFixoFabricaNac,CrnMCNac,CrnMCNacPct,CrnCustoFixoAdmComNac,CrnResultadoBrutoNac,CrnResultadoBrutoNacPct,CrnComentario,PqeCriterio,PqeAumDim,PqeQtExpAnoMenos12,PqeQtExpAnoMenos11,PqeQtExpAnoMenos10,PqeQtExpAnoMenos9,PqeQtExpAnoMenos8,PqeQtExpAnoMenos7,PqeQtExpAnoMenos6,PqeQtExpAnoMenos5,PqeQtExpAnoMenos4,PqeQtExpAnoMenos3,PqeQtExpAnoMenos2,PqeQtExpAno,PqeQtExpTotal,PpleKgExpAnoMenos12,PpleKgExpAnoMenos11,PpleKgExpAnoMenos10,PpleKgExpAnoMenos9,PpleKgExpAnoMenos8,PpleKgExpAnoMenos7,PpleKgExpAnoMenos6,PpleKgExpAnoMenos5,PpleKgExpAnoMenos4,PpleKgExpAnoMenos3,PpleKgExpAnoMenos2,PpleKgExpAno,PpleKgExpTotal,PvppvaVPVexAnoMenos12,PvppvaVPVexAnoMenos11,PvppvaVPVexAnoMenos10,PvppvaVPVexAnoMenos9,PvppvaVPVexAnoMenos8,PvppvaVPVexAnoMenos7,PvppvaVPVexAnoMenos6,PvppvaVPVexAnoMenos5,PvppvaVPVexAnoMenos4,PvppvaVPVexAnoMenos3,PvppvaVPVexAnoMenos2,PvppvaVPVexAno,PreUsdRcExpUsAnoMenos12,PreUsdRcExpUsAnoMenos11,PreUsdRcExpUsAnoMenos10,PreUsdRcExpUsAnoMenos9,PreUsdRcExpUsAnoMenos8,PreUsdRcExpUsAnoMenos7,PreUsdRcExpUsAnoMenos6,PreUsdRcExpUsAnoMenos5,PreUsdRcExpUsAnoMenos4,PreUsdRcExpUsAnoMenos3,PreUsdRcExpUsAnoMenos2,PreUsdRcExpUsAno,PreUsdRcExpUsRecExportUSD,CreRecExportRs,CreComissaoExportRs,CreFreteDespExportRs,CreRecLiqVendaExportRs,CreCustoDiretoMatModExptRs,CreCustoFixoFabExpRs,CreMCExportRs,CreMCExportPct,CreCustoFixoAdmComExpRs,CreResultadoBrutoExpRs,CreResBrutoExpPct,FbQuantTotal,FbPesoTotal,FbFaturamentoBrutoTotal,RlImpostoTotal,RlReceitaLiquidaTotal,RlComissaoTotal,RlFreteDespExpTotal,RlRecLiqVendaTotal,McCustoDirMatModTotal,McCustoFixoFabricaTotal,McMargemContribTotal,McMCbTotalPct,RoCustoFixoComAdmTotal,RoCustoFixoComAdmAjustadoTotal,RoResultadoOperacionalTotal,RoResultadoOperacionalTotalPct,CdTotAnoMenos12,CdTotAnoMenos11,CdTotAnoMenos10,CdTotAnoMenos9,CdTotAnoMenos8,CdTotAnoMenos7,CdTotAnoMenos6,CdTotAnoMenos5,CdTotAnoMenos4,CdTotAnoMenos3,CdTotAnoMenos2,CdTotAno,GifTotAnoMenos12,GifTotAnoMenos11,GifTotAnoMenos10,GifTotAnoMenos9,GifTotAnoMenos8,GifTotAnoMenos7,GifTotAnoMenos6,GifTotAnoMenos5,GifTotAnoMenos4,GifTotAnoMenos3,GifTotAnoMenos2,GifTotAno,ComTotAnoMenos12,ComTotAnoMenos11,ComTotAnoMenos10,ComTotAnoMenos9,ComTotAnoMenos8,ComTotAnoMenos7,ComTotAnoMenos6,ComTotAnoMenos5,ComTotAnoMenos4,ComTotAnoMenos3,ComTotAnoMenos2,ComTotAno,FrtNacAnoMenos12,FrtNacAnoMenos11,FrtNacAnoMenos10,FrtNacAnoMenos9,FrtNacAnoMenos8,FrtNacAnoMenos7,FrtNacAnoMenos6,FrtNacAnoMenos5,FrtNacAnoMenos4,FrtNacAnoMenos3,FrtNacAnoMenos2,FrtNacAno,FrDexpAnoMenos12,FrDexpAnoMenos11,FrDexpAnoMenos10,FrDexpAnoMenos9,FrDexpAnoMenos8,FrDexpAnoMenos7,FrDexpAnoMenos6,FrDexpAnoMenos5,FrDexpAnoMenos4,FrDexpAnoMenos3,FrDexpAnoMenos2,FrDexpAno,CdsmtCfMatAnoMenos12,CdsmtCfMatAnoMenos11,CdsmtCfMatAnoMenos10,CdsmtCfMatAnoMenos9,CdsmtCfMatAnoMenos8,CdsmtCfMatAnoMenos7,CdsmtCfMatAnoMenos6,CdsmtCfMatAnoMenos5,CdsmtCfMatAnoMenos4,CdsmtCfMatAnoMenos3,CdsmtCfMatAnoMenos2,CdsmtCfMatAno,QtvQtTottAnoMenos12,QtvQtTottAnoMenos11,QtvQtTottAnoMenos10,QtvQtTottAnoMenos9,QtvQtTottAnoMenos8,QtvQtTottAnoMenos7,QtvQtTottAnoMenos6,QtvQtTottAnoMenos5,QtvQtTottAnoMenos4,QtvQtTottAnoMenos3,QtvQtTottAnoMenos2,QtvQtTottAno,HorasProdAnoMenos12,HorasProdAnoMenos11,HorasProdAnoMenos10,HorasProdAnoMenos9,HorasProdAnoMenos8,HorasProdAnoMenos7,HorasProdAnoMenos6,HorasProdAnoMenos5,HorasProdAnoMenos4,HorasProdAnoMenos3,HorasProdAnoMenos2,HorasProdAno,RecNacAnoMenos12,RecNacAnoMenos11,RecNacAnoMenos10,RecNacAnoMenos9,RecNacAnoMenos8,RecNacAnoMenos7,RecNacAnoMenos6,RecNacAnoMenos5,RecNacAnoMenos4,RecNacAnoMenos3,RecNacAnoMenos2,RecNacAno,RecExpAnoMenos12,RecExpAnoMenos11,RecExpAnoMenos10,RecExpAnoMenos9,RecExpAnoMenos8,RecExpAnoMenos7,RecExpAnoMenos6,RecExpAnoMenos5,RecExpAnoMenos4,RecExpAnoMenos3,RecExpAnoMenos2,RecExpAno")] PlanejVenda planejVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planejVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", planejVenda.ProdutoId);
            return View(planejVenda);
        }

        // GET: PlanejVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlanejVenda planejVenda = db.PlanejVendas
                .Include(p => p.Produto)
                .SingleOrDefault(p => p.Id == id);

            if (planejVenda == null)
            {
                return HttpNotFound();
            }
            return View(planejVenda);
        }

        // POST: PlanejVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanejVenda planejVenda = db.PlanejVendas
                .Include(p => p.Produto)
                .SingleOrDefault(p => p.Id == id);

            return View("Erase", planejVenda);
        }

        // POST: PlanejVendas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            PlanejVenda planejVenda = db.PlanejVendas.Find(id);
            db.PlanejVendas.Remove(planejVenda);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var planejVenda = db.PlanejVendas
                .Include(p => p.Produto)
                .SingleOrDefault(p => p.Produto.Apelido == search);

            if (planejVenda == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo produto {search} não produziu resultado em PlanejVenda");
                return Content($"Item {search} não encontrado");
            }
            return View("Details", planejVenda);
        }

        [HttpPost]
        public ActionResult Incremento(float incremento)
        {
            Memoria memoria = db.Memorias.First();
            memoria.PvIncrementoGlobal = incremento / 100;
            db.SaveChanges();
            ViewBag.incremento = incremento;
            Populate.PlanejVendas();
            var planejVendas = db.PlanejVendas
                .Include(p => p.Produto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DespExp(float despExp)
        {
            Memoria memoria = db.Memorias.First();
            memoria.DespExp = despExp / 100;
            db.SaveChanges();
            ViewBag.despExp = despExp;
            Populate.PlanejVendas();
            var planejVendas = db.PlanejVendas
                .Include(p => p.Produto);

            return RedirectToAction("Index");
        }

        public ViewResult VarTc()
        {
            var tcs = new List<VarTc>();
            var lista = db.PlanejVendas.ToList();

            foreach (var item in lista)
            {
                var produto = db.Produtos.Single(p => p.Id == item.ProdutoId);
                var tc = new VarTc
                {
                    Id = item.ProdutoId,
                    Apelido = produto.Apelido,
                    Descricao = produto.Descricao,
                    Criterio = item.Criterio,
                    VarTc1 = item.VartC1,
                    VarTc2 = item.VarTc2,
                    VarTc3 = item.VartC3,
                    VarTc4 = item.VartC4
                };

                tcs.Add(tc);
            }

            return View(tcs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VarTc(List<VarTc> varTc)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in varTc)
                {
                    var atual = db.PlanejVendas.Single(p => p.ProdutoId == item.Id);
                    atual.Criterio = item.Criterio;
                    atual.VartC1 = item.VarTc1;
                    atual.VarTc2 = item.VarTc2;
                    atual.VartC3 = item.VarTc3;
                    atual.VartC4 = item.VarTc4;

                    db.SaveChanges();
                }

                Populate.PlanejVendas();

                return RedirectToAction("Index");
            }

            return RedirectToAction("VarTc");
        }

        public ViewResult VarPv()
        {
            var pvs = new List<VarPv>();
            var lista = db.PlanejVendas.ToList();

            foreach (var item in lista)
            {
                var produto = db.Produtos.Single(p => p.Id == item.ProdutoId);
                var pv = new VarPv
                {
                    Id = item.ProdutoId,
                    Apelido = produto.Apelido,
                    Descricao = produto.Descricao,
                    VarPvMenos01 = item.PvvpvaVarPvAno,
                    VarPvMenos02 = item.PvvpvaVarPvAnoMenos2,
                    VarPvMenos03 = item.PvvpvaVarPvAnoMenos3,
                    VarPvMenos04 = item.PvvpvaVarPvAnoMenos4,
                    VarPvMenos05 = item.PvvpvaVarPvAnoMenos5,
                    VarPvMenos06 = item.PvvpvaVarPvAnoMenos6,
                    VarPvMenos07 = item.PvvpvaVarPvAnoMenos7,
                    VarPvMenos08 = item.PvvpvaVarPvAnoMenos8,
                    VarPvMenos09 = item.PvvpvaVarPvAnoMenos9,
                    VarPvMenos10 = item.PvvpvaVarPvAnoMenos10,
                    VarPvMenos11 = item.PvvpvaVarPvAnoMenos11,
                    VarPvMenos12 = item.PvvpvaVarPvAnoMenos12
                };

                pvs.Add(pv);
            }

            return View(pvs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VarPv(List<VarPv> varPv)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in varPv)
                {
                    var atual = db.PlanejVendas.Single(p => p.ProdutoId == item.Id);
                    atual.PvvpvaVarPvAnoMenos12 = item.VarPvMenos12;
                    atual.PvvpvaVarPvAnoMenos11 = item.VarPvMenos11;
                    atual.PvvpvaVarPvAnoMenos10 = item.VarPvMenos10;
                    atual.PvvpvaVarPvAnoMenos9 = item.VarPvMenos09;
                    atual.PvvpvaVarPvAnoMenos8 = item.VarPvMenos08;
                    atual.PvvpvaVarPvAnoMenos7 = item.VarPvMenos07;
                    atual.PvvpvaVarPvAnoMenos6 = item.VarPvMenos06;
                    atual.PvvpvaVarPvAnoMenos5 = item.VarPvMenos05;
                    atual.PvvpvaVarPvAnoMenos4 = item.VarPvMenos04;
                    atual.PvvpvaVarPvAnoMenos3 = item.VarPvMenos03;
                    atual.PvvpvaVarPvAnoMenos2 = item.VarPvMenos02;
                    atual.PvvpvaVarPvAno = item.VarPvMenos01;
                }

                db.SaveChanges();

                Populate.PlanejVendas();

                return RedirectToAction("Index");
            }

            return RedirectToAction("VarPv");
        }

        public ViewResult Aumdim()
        {
            var ads = new List<Aumdim>();
            var lista = db.PlanejVendas.ToList();

            foreach (var item in lista)
            {
                var produto = db.Produtos.Single(p => p.Id == item.ProdutoId);
                var ad = new Aumdim
                {
                    Id = item.ProdutoId,
                    Apelido = produto.Apelido,
                    Descricao = produto.Descricao,
                    Criterio = item.PqeCriterio,
                    Aum = item.PqeAumDim
                };

                ads.Add(ad);
            }

            return View(ads);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aumdim(List<Aumdim> aumdim)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in aumdim)
                {
                    var atual = db.PlanejVendas.Single(p => p.ProdutoId == item.Id);
                    atual.PqeCriterio = item.Criterio;
                    atual.PqeAumDim = item.Aum;
                }

                db.SaveChanges();

                Populate.PlanejVendas();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Aumdim");
        }

        public ViewResult Varvex()
        {
            var vvs = new List<VarVex>();
            var lista = db.PlanejVendas.ToList();

            foreach (var item in lista)
            {
                var produto = db.Produtos.Single(p => p.Id == item.ProdutoId);
                var vv = new VarVex
                {
                    Id = item.ProdutoId,
                    Apelido = produto.Apelido,
                    Descricao = produto.Descricao,
                    Criterio = item.PqeCriterio,
                    VpVexMenos12 = item.PvppvaVPVexAnoMenos12 * 100f,
                    VpVexMenos11 = item.PvppvaVPVexAnoMenos11 * 100f,
                    VpVexMenos10 = item.PvppvaVPVexAnoMenos10 * 100f,
                    VpVexMenos09 = item.PvppvaVPVexAnoMenos9 * 100f,
                    VpVexMenos08 = item.PvppvaVPVexAnoMenos8 * 100f,
                    VpVexMenos07 = item.PvppvaVPVexAnoMenos7 * 100f,
                    VpVexMenos06 = item.PvppvaVPVexAnoMenos6 * 100f,
                    VpVexMenos05 = item.PvppvaVPVexAnoMenos5 * 100f,
                    VpVexMenos04 = item.PvppvaVPVexAnoMenos4 * 100f,
                    VpVexMenos03 = item.PvppvaVPVexAnoMenos3 * 100f,
                    VpVexMenos02 = item.PvppvaVPVexAnoMenos2 * 100f,
                    VpVexMenos01 = item.PvppvaVPVexAno * 100f
                };

                vvs.Add(vv);
            }

            return View(vvs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Varvex(List<VarVex> varvex)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in varvex)
                {
                    var atual = db.PlanejVendas.Single(p => p.ProdutoId == item.Id);
                    atual.PvppvaVPVexAnoMenos12 = item.VpVexMenos12 / 100f;
                    atual.PvppvaVPVexAnoMenos11 = item.VpVexMenos11 / 100f;
                    atual.PvppvaVPVexAnoMenos10 = item.VpVexMenos10 / 100f;
                    atual.PvppvaVPVexAnoMenos9 = item.VpVexMenos09 / 100f;
                    atual.PvppvaVPVexAnoMenos8 = item.VpVexMenos08 / 100f;
                    atual.PvppvaVPVexAnoMenos7 = item.VpVexMenos07 / 100f;
                    atual.PvppvaVPVexAnoMenos6 = item.VpVexMenos06 / 100f;
                    atual.PvppvaVPVexAnoMenos5 = item.VpVexMenos05 / 100f;
                    atual.PvppvaVPVexAnoMenos4 = item.VpVexMenos04 / 100f;
                    atual.PvppvaVPVexAnoMenos3 = item.VpVexMenos03 / 100f;
                    atual.PvppvaVPVexAnoMenos2 = item.VpVexMenos02 / 100f;
                    atual.PvppvaVPVexAno = item.VpVexMenos01 / 100f;
                }

                db.SaveChanges();

                Populate.PlanejVendas();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Varvex");
        }

        public ViewResult GerarPlanejVendas()
        {
            var dia = new Dia();
            dia.Hoje = DateTime.Today;
            return View(dia);
        }

        [HttpPost]
        public ActionResult GerarPlanejVendas(Dia dia)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM dbo.PlanejVendas");
                var produtos = db.Produtos.ToList();

                foreach (var produto in produtos)
                {
                    if (produto.Ativo)
                    {
                        var data = new PlanejVenda
                        {
                            ProdutoId = produto.Id,
                            RefAno = dia.Hoje
                        };

                        db.PlanejVendas.Add(data);
                    }
                }
                db.SaveChanges();
            }

            Populate.PlanejVendas();

            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
